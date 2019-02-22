using Know_Your_Nation_Speedy.Models;
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

        /// POST : 
        [HttpPost("login")]
        public IActionResult Login([FromBody] User User)
        {
            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
            PasswordBasedKeyDerivationFunction obj = new PasswordBasedKeyDerivationFunction();
            if (ExistingUser != null)
            {
                string Pass = obj.Decrypt(ExistingUser.Password);
                if (Pass != User.Password)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                return Ok();
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
            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);
            if (User.Name == null || User.Password == null || User.Surname == null)
            {
                return BadRequest();
            }
            else
            {
                /* I will come back to attend this code for testing for now I am pushing for my team to access my work**/
                //var hasNumber = new Regex(@"[0-9]+");
                //var hasUpperChar = new Regex(@"[A-Z]+");
                //var hasLowerChar = new Regex(@"[a-z]+");
                //var hasSpecialChar = new Regex(@"[!@#$%^&*()]+_-`~");
                //var hasMinimum8Chars = new Regex(@".{8,}");
                string Error = " ";
                //bool isValidated = hasLowerChar.IsMatch(User.Password)&& hasSpecialChar.IsMatch(User.Password) && hasNumber.IsMatch(User.Password) && hasUpperChar.IsMatch(User.Password) && hasMinimum8Chars.IsMatch(User.Password);
                var isPassGood = Regex.IsMatch(User.Password, @"(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
                if (ExistingUser == null && isPassGood)
                {

                    User.Password = obj.encrypt(User.Password);
                    _db.UserEntries.Add(User);
                    _db.SaveChanges();
                    return Ok(new { message = "Successfully registered .." });
                }
                else
                {
                    if (!(isPassGood))
                    {
                        Error += "Password must atlest have 1 special case, 1 capital case, 1 lower case and be of 8 length atleast";

                    }
                    else if (ExistingUser == null)
                    {

                        Error += "\n The email already exist, please try to sign up with a new email. ";
                    }
                    else
                    {

                    }
                    return BadRequest(new { message = Error });
                }
            }
        }

        [HttpPost]
        public async Task Post([FromBody] User User)
        {
            var ExistingUser = _db.UserEntries.FirstOrDefault(o => o.Email == User.Email);   
            if (ExistingUser == null )
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
    }
}
