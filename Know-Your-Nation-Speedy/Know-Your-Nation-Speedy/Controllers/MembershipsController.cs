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
    public class MembershipsController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public MembershipsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membership>>> Get()
        {
            return await _db.MembershipEntries.ToListAsync();
        }

        [HttpPost("CreateMembership")]
        public async Task<IActionResult> CreateMembership([FromBody] Membership membership)
        {
            await _db.MembershipEntries.AddAsync(membership);
            await _db.SaveChangesAsync();
            var entry = await _db.MembershipEntries.FindAsync(membership.Id);
            if (entry != null)
            {
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: Membership not found" });
            }

        }
        [HttpPost("EditMembership")]
        public async Task<IActionResult> EditMembership(int id, [FromBody] Membership membership)
        {
            var entry = await _db.MembershipEntries.FindAsync(id);
            if (entry != null)
            {
                entry = membership;
                _db.MembershipEntries.Update(entry);
                await _db.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound(new { error = "Error: Membership not found" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.MembershipEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.MembershipEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
