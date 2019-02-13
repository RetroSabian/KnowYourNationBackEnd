using Know_Your_Nation_Speedy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    { 

        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public DbController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _db.UserEntries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            var entry = await _db.UserEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.UserEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] User value)
        {
            await _db.UserEntries.AddAsync(value);
            await _db.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
            var entry = await _db.UserEntries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
          
            var entry = await _db.UserEntries.SingleOrDefaultAsync(m=> m.Id==id);
            if (entry == null) {
                return NotFound();

            }
            _db.UserEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}

