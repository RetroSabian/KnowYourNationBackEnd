using Know_Your_Nation_Speedy.Models;
using Know_Your_Nation_Speedy.Request;
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
    public class ContentsController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public ContentsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpPost("GetContent")]
        public async Task<ActionResult<IEnumerable<ContentDetailed>>> GetContent([FromBody] ContentRequest contentRequest)
        {
            
                 var entry = await _db.ContentEntries
                      .Include(o => o.UserBookmark)
                      .Include(o => o.UserRating)
                      .Where(o => o.Category == contentRequest.Category && o.Association == contentRequest.Association)
                      .Select(p => new ContentDetailed
                      {
                          ContentId = p.Id,
                          Name = p.Name,
                          FileLocation = p.FileLocation,
                          Description = p.Description,
                          ImageLocation = p.ImageLocation,
                          Category = p.Category,
                          Association = p.Association,
                          //Rating = p.UserRating != null ? p.UserRating.Where(o => o.UserId == contentRequest.UserId).FirstOrDefault().Rating : 0,
                          //Bookmark = p.UserBookmark != null ?  p.UserBookmark.Where(o => o.UserId == contentRequest.UserId).FirstOrDefault().Bookmark : false
                      })
                     .ToListAsync();        
                 if (entry != null)
                 {
                     return Ok(entry);
                 }
                 else
                 {
                     return NotFound(new { error = "Content is empty" });
                 }
             }

        [HttpPost("CreateContent")]
        public async Task<IActionResult> CreateContent([FromBody] Content content)
        {
            await _db.ContentEntries.AddAsync(content);
            await _db.SaveChangesAsync();
            var entry = await _db.ContentEntries.FindAsync(content.Id);
            if (entry != null)
            {
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: Content not Created" });
            }

        }
        [HttpPost("EditContent")]
        public async Task<IActionResult> EditContent([FromBody] Content content)
        {
            var entry = await _db.ContentEntries.FindAsync(content.Id);
            if (entry != null)
            {
                entry.Name = content.Name;
                entry.FileLocation = content.FileLocation;
                entry.ImageLocation = content.ImageLocation;
                entry.Description = content.Description;
                entry.Category = content.Category;
                entry.Association = content.Association;
                _db.ContentEntries.Update(entry);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: Content not found" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.ContentEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.ContentEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
