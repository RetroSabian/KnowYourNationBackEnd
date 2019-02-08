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
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public UsersController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await _db.UsersEntries.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            var entry = await _db.UsersEntries.SingleOrDefaultAsync(m => m.UsersId == id);
            

            if (entry == null)
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
        [HttpGet("login")]
        public ActionResult<Users> Login(string username, string pass)
        {
            var user = _db.UsersEntries.Where(o => o.Email == username).FirstOrDefault();
            if (user != null)
            {
                if (user.Password != pass)
                {
                    return BadRequest("The username/password is incorrect");
                }
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task Post([FromBody] Users Body)
        {
            await _db.UsersEntries.AddAsync(Body);
            await _db.SaveChangesAsync();
        }
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Users Body)
        {
            var entry = await _db.UsersEntries.FindAsync(id);
            entry = Body;
            await _db.SaveChangesAsync();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
        {
            var entry = await _db.UsersEntries.SingleOrDefaultAsync(m => m.UsersId == id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.UsersEntries.Remove(entry);
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
