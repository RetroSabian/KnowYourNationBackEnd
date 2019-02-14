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

        private Users _model;
        EmailService mailS = new EmailService();
        private MyDbContext _db;
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

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] Users User)
        {
            var ExistingUser = _db.UsersEntries.Where(o => o.Email == User.Email).FirstOrDefault();
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
        public async Task Post([FromBody] Users User)
        {
            await _db.UsersEntries.AddAsync(User);
            await _db.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Users User)
        {
            var entry = await _db.UsersEntries.FindAsync(id);
            entry = User;
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

        [HttpPut()]
        [Route("ForgotPassword/{mail}")]
        public ActionResult getCodes(string mail)
        {
            string code = mailS.generateCode();

            mailS.SendMail(mail, "testing", code);
            _db.SaveChanges();
            return Ok(mail);
        }

        // PUT api/values/5
        [HttpPut()]
        [Route("ResetPassword/{password} + {mail}")]
        public async Task ResetPassword(string mail,string password)
        {
            var entry = await _db.UsersEntries.SingleOrDefaultAsync(m => m.Email == mail);
            entry.Password = password;
            _db.UsersEntries.Update(entry);
            await _db.SaveChangesAsync();
        }


    }
}
