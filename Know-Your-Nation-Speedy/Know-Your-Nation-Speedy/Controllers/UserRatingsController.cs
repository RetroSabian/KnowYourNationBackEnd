using Know_Your_Nation_Speedy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRatingsController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public UserRatingsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpGet("GetLink")]
        public async Task<ActionResult<IEnumerable<UserRating>>> GetLink([FromBody] UserRating userContent)
        {
            List<UserRating> entry = await _db.UserRatingEntries.Where(u => u.UserId == userContent.UserId).Where(c => c.ContentId == userContent.ContentId).ToListAsync();
            if (entry != null)
            {
                return Ok(entry);
            }
            else
            {
                return NotFound(new { error = "Link Error" });
            }
        }

        [HttpPost("CreateUserRating")]
        public async Task<IActionResult> CreateUserRating([FromBody] UserRating userContent)
        {
            await _db.UserRatingEntries.AddAsync(userContent);
            await _db.SaveChangesAsync();
            var entry = await _db.UserRatingEntries.FindAsync(userContent.Id);
            if (entry != null)
            {
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: UserRating not Created" });
            }

        }
        [HttpPost("EditUserRating")]
        public async Task<IActionResult> EditUserRating([FromBody] UserRating userContent)
        {
            var entry = await _db.UserRatingEntries.FindAsync(userContent.Id);
            if (entry != null)
            {
                
                _db.UserRatingEntries.Update(entry);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: UserRating not found" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.UserRatingEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.UserRatingEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
