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
    public class VolunteerController : ControllerBase
    {
        private readonly MyDbContext _db;
        readonly IConfiguration _config;
        public VolunteerController(MyDbContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        [HttpGet("events")]
        public ActionResult<Event> EventName()
        {
            try
            {
                var events = _db.EventEntries.ToArray();
                if (events != null)
                {
                    return Ok(events);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("existingevents")]
        public ActionResult<Event> Event()
        {
            try
            {
                var datenow = DateTime.Now;
                var events = _db.EventEntries.ToArray().Select(o => new { o.Id,o.Date, o.Name }).Where(d => DateTime.Compare(datenow, d.Date) < 0).ToArray() ;
                if (events != null)
                {                   
                        return Ok(events);                 
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("numVolunteers")]
        public ActionResult<UserEvent> numVolunteer()
        {
            try
            {
                int events = _db.UserEventEntries.Select(o => o.UserId).Distinct().Count();
                if (events != 0)
                {

                    return Ok(events);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("numEvents")]
        public ActionResult<Event> numEvent()
        {
            try
            {
                int events = _db.EventEntries.Select(o => o.Id).Count();
                if (events != 0)
                {

                    return Ok(events);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("historyevents")]
        public ActionResult<Event> History()
        {
            try
            {
                var datenow = DateTime.Now;
                var events = _db.EventEntries.ToArray().Select(o => new { o.Date, o.Name }).Where(d => DateTime.Compare(datenow, d.Date) > 0).ToArray();
                if (events != null)
                {

                    return Ok(events);
                }
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getevents")]
        public ActionResult<Event> GetEventById(int? id)
        {
            try
            {
                if(id ==null)
                {
                    return null;
                }
                var events = _db.EventEntries.Where(i=> i.Id==id).FirstOrDefault();
                if (events != null)
                {
                    return Ok(events);
                }   
                return null;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
  
        [HttpPost("postevent")]
        public ActionResult<Event> Post([FromBody] Event events)
        {
            if (events.Name == null && events.Description == null && events.City == null && events.Street == null && events.PostalCode ==null && events.Suburb == null)
            {
                return BadRequest(new { Error = "Event not fully loaded" });
            }
            else
            {
                _db.EventEntries.AddAsync(events);
                _db.SaveChangesAsync();
                return Ok(events);
            }
        } 
    }
}