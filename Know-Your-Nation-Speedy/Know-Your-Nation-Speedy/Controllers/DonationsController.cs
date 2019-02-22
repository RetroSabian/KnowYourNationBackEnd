using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know_Your_Nation_Speedy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Know_Your_Nation_Speedy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : Controller
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public DonationsController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpPost("Donate")]
        public async Task AddDonation([FromBody] Donation donate)
        {
            await _db.DonationEntries.AddAsync(donate);
            await _db.SaveChangesAsync();
        }

        [HttpPost("Organisation")]
        public async Task AddOrganisation([FromBody] Organisation organisation)
        {
            await _db.OrganisationEntries.AddAsync(organisation);
            await _db.SaveChangesAsync();
        }


        [HttpGet("getMemberDonations/{id}")]
        public ActionResult<Donation> memberDonations(int id)
        {
            try
            {
                var donations = _db.DonationEntries.ToArray().Select(o => new { o.DonatationAmount, o.OrganisationId, o.UserId }).Where(d => int.Equals(id, d.UserId)).ToArray();
                return Ok(donations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getDonations")]
        public ActionResult<Donation> DonationsAmount()
        {
            try
            {
                var donations = _db.DonationEntries.Select(o => o.DonatationAmount).ToArray().Sum();
                if (donations != 0)
                {           
                    return Ok(donations);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Organisation")]
        public ActionResult<Donation> OrganisationName()
        {
            try
            {
                var Organisations = _db.OrganisationEntries.ToArray();
                if (Organisations != null)
                {
                    return Ok(Organisations);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
