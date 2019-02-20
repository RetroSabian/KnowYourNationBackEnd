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
    public class UserContentsController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public UserContentsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpGet("GetLink")]
        public async Task<ActionResult<IEnumerable<UserContent>>> GetLink([FromBody] UserContent userContent)
        {
            List<UserContent> entry = await _db.UserContentEntries.Where(u => u.UserId == userContent.UserId).Where(c => c.ContentId == userContent.ContentId).ToListAsync();
            if (entry != null)
            {
                return Ok(entry);
            }
            else
            {
                return NotFound(new { error = "Link Error" });
            }
        }

        [HttpPost("CreateUserContent")]
        public async Task<IActionResult> CreateUserContent([FromBody] UserContent userContent)
        {
            await _db.UserContentEntries.AddAsync(userContent);
            await _db.SaveChangesAsync();
            var entry = await _db.UserContentEntries.FindAsync(userContent.Id);
            if (entry != null)
            {
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: UserContent not Created" });
            }

        }
        [HttpPost("EditUserContent")]
        public async Task<IActionResult> EditUserContent([FromBody] UserContent userContent)
        {
            var entry = await _db.UserContentEntries.FindAsync(userContent.Id);
            if (entry != null)
            {
                entry.ReadStatus = userContent.ReadStatus;
                entry.Bookmark = userContent.Bookmark;
                entry.Rating = userContent.Rating;
                entry.Allocated = userContent.Allocated;
                _db.UserContentEntries.Update(entry);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: UserContent not found" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.UserContentEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.UserContentEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
