using Know_Your_Nation_Speedy.Models;
using Know_Your_Nation_Speedy.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know_Your_Nation_Speedy.Logic;
using System.Text.RegularExpressions;

namespace Know_Your_Nation_Speedy.Controllers
{
    [Route("api/users")]
    //[Route("api/[controller]")]
    //ApiController]
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
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _db.UserEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetEntry([FromRoute] int id)
        {
            var entry = _db.UserEntries.Where(o => o.Id == id);

            if (entry == null)
            {
                return NotFound();
            }
            _db.SaveChangesAsync();
            return Ok(entry);
        }



        /// POST : 
        [HttpPost("login")]
        public IActionResult Login([FromBody] User User)
        {
            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
            PasswordBasedKeyDerivationFunction obj = new PasswordBasedKeyDerivationFunction();
            if (ExistingUser != null && User.Email.Length != 0)
            {
                string Pass = obj.Decrypt(ExistingUser.Password);
                if (Pass != User.Password)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                return Ok(ExistingUser);
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }


        /// POST :
        [HttpPost("register")]
        public IActionResult Register([FromBody] User User)
        {
            User.MembershipId = 11;
            PasswordBasedKeyDerivationFunction obj = new PasswordBasedKeyDerivationFunction();
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSpecialChar = new Regex(@"[a-zA-Z0-9 ]*$");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
            if (User.Name == null || User.Password == null || User.Surname == null | !hasLowerChar.IsMatch(User.Password) | !hasUpperChar.IsMatch(User.Password) | !hasNumber.IsMatch(User.Password) | !hasSpecialChar.IsMatch(User.Password) | !hasMinimum8Chars.IsMatch(User.Password))
            {
                return BadRequest(new { message = "Password must have atleast 8 characters, 1 lower case , 1 upper case , 1 number & 1 special letter " });
            }
            else
            { //TO-DO
              /* I will come back to attend this code for testing for now I am pushing for my team to access my work**/

                string Error = " ";

                if (ExistingUser == null)
                {

                    User.Password = obj.encrypt(User.Password);
                    _db.UserEntries.Add(User);
                    _db.SaveChanges();
                    var getUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
                    var getUserId = getUser.Id;

                    return Ok(new { getUser.Id, getUser.Name, getUser.Surname });
                }
                else
                {
                    if (ExistingUser.Email != null)
                    {

                        Error += "\n The email already exist, please try to sign up with a new email. ";
                    }

                    return BadRequest(new { message = Error });
                }
            }
        }

        [HttpPost("update")]
        public async Task update([FromBody] User User)
        {
            PasswordBasedKeyDerivationFunction obj = new PasswordBasedKeyDerivationFunction();
            var entry = await _db.UserEntries.FindAsync(User.Id);
            if (entry == null)
            {

            }
            entry.Email = User.Email;
            entry.Name = User.Name;
            entry.PhoneNumber = User.PhoneNumber;
            entry.Surname = User.Surname;
            entry.MembershipExpiration = User.MembershipExpiration;
            entry.Password = obj.Decrypt(User.Password);
            _db.UserEntries.Update(entry);
            await _db.SaveChangesAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] User User)
        {
            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
            if (ExistingUser == null)
            {
                await _db.UserEntries.AddAsync(User);
                await _db.SaveChangesAsync();
                // return Ok(new { message = "Successfully registered .." });
            }
            else
            {
                // return BadRequest(new { message = " registered failed" });
            }

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
            var entry = await _db.UserEntries.FindAsync(mail);
            EmailService Es = new EmailService();
            if (entry != null)
            {
                Es.SendMail(mail, "testing");
            }
        }
        // PUT api/values/5
        [HttpPut()]
        [Route("ResetPassword/{password} + {mail}")]
        public async Task ResetPassword(string mail, string password)
        {
            var entry = await _db.UserEntries.SingleOrDefaultAsync(m => m.Email == mail);
            entry.Password = password;
            _db.UserEntries.Update(entry);
            await _db.SaveChangesAsync();
        }
    }
}