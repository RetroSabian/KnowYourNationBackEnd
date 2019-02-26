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
    public class ContentsController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public ContentsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpPost("GetBooks")]
        public async Task<ActionResult<IEnumerable<ContentDetailed>>> GetBook([FromBody] UserId userContent)
        {
            /* try
             {
                 var entry = await _db.ContentEntries
                      .Include(o => o.UserContent)
                      .Where(o => o.Category == "Book" && o.UserContent != null)
                      .Select(p => new ContentDetailed
                      {
                          ContentId = p.Id,
                          Name = p.Name,
                          FileLocation = p.FileLocation,
                          Description = p.Description,
                          ImageLocation = p.ImageLocation,
                          Rating = p.UserContent.FirstOrDefault().Rating,
                          Bookmark = p.UserContent.FirstOrDefault().Bookmark,
                          Allocated = p.UserContent.FirstOrDefault().Allocated,
                          ReadStatus = p.UserContent.FirstOrDefault().ReadStatus

                          //UserInfo= p.UserContent.Where(i => i.UserId == userContent.UserId && i.ContentId == p.Id).FirstOrDefault()
                      })
                     .ToListAsync();

                 var testdata = (from i in _db.ContentEntries
                                 join u in _db.UserContentEntries on i.Id equals u.ContentId into joiT
                                 from p in joiT.DefaultIfEmpty()
                                 where i.Category=="Book" && p.UserId == userContent.Id
                                 select new {
                                     i.Name,
                                     i.FileLocation,
                                     bookmark = p != null? p.Bookmark : false,
                                     rating = p != null ? p.Rating :0
                                 }).ToList();
                 if (entry != null)
                 {
                     return Ok(entry);
                 }
                 else
                 {
                     return NotFound(new { error = "Books are empty" });
                 }
             }
             catch(System.Exception ex)
             {
                 return NotFound(new { error = ex.Message });

             }*/
            return null; 
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
