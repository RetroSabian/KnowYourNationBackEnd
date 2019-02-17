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
    public class UsersController : ControllerBase
    {

        EmailService emailService = new EmailService();
        private MyDbContext _db;
        readonly IConfiguration _config;
        public UsersController(MyDbContext context, IConfiguration config)
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] int id)
        {
            var entry = await _db.UserEntries.SingleOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            await _db.SaveChangesAsync();
            return Ok(entry);
        }
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] User User)
        {
            var ExistingUser = _db.UserEntries.Where(o => o.Email == User.Email).FirstOrDefault();
            if (ExistingUser != null)
            {
                if (ExistingUser.Password != User.Password)
                {
                    return new JsonResult("{Status: \"Invalid Username or Password\"}");
                }
                return Ok(User);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task Post([FromBody] User User)
        {
            await _db.UserEntries.AddAsync(User);
            await _db.SaveChangesAsync();
        }
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User User)
        {
            var entry = await _db.UserEntries.FindAsync(id);
            entry = User;
            await _db.SaveChangesAsync();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute]int id)
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
        [HttpPut()]
        [Route("ForgotPassword/{mail}")]
        public async Task getCodes(string mail)
        {
            string code = emailService.generateCode();
            var entry = await _db.UserEntries.FindAsync(mail);

            if (entry != null)
            {
                emailService.SendMail(mail, "testing", code);
            }
        }
        // PUT api/values/5
        [HttpPut()]
        [Route("ResetPassword/{password} + {mail}")]
        public async Task ResetPassword(string mail,string password)
        {
            var entry = await _db.UserEntries.SingleOrDefaultAsync(m => m.Email == mail);
            entry.Password = password;
            _db.UserEntries.Update(entry);
            await _db.SaveChangesAsync();
        }
    }
}
