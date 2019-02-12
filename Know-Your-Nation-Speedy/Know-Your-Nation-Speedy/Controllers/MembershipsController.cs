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
        public async Task<ActionResult<IEnumerable<Memberships>>> Get()
        {
            return await _db.MembershipsEntries.ToListAsync();
        }

        [HttpPost("CreateEditMembership")]
        public async Task Post([FromBody] Memberships membership)
        {
            await _db.MembershipsEntries.AddAsync(membership);
            await _db.SaveChangesAsync();
        }
    }
}
