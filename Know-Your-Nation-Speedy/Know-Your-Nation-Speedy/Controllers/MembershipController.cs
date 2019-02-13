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
    public class MembershipController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public MembershipController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membership>>> Get()
        {
            return await _db.MembershipEntries.ToListAsync();
        }

        [HttpPost("CreateEditMembership")]
        public async Task Post([FromBody] Membership membership)
        {
            await _db.MembershipEntries.AddAsync(membership);
            await _db.SaveChangesAsync();
        }
    }
}
