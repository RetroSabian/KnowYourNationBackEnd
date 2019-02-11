using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Events
    {
        public Events()
        {
            Initialise();
        }
        public int EventsId { get; set; }
        public string EventName { get; set;}
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string EventStreet { get; set; }
        public string EventSuburb { get; set; }
        public string EventCity { get; set; }
        public string EventPostalCode { get; set; }
        public Organisations Organisation { get; set; }
        public ICollection<UserEvents> UserEvent { get; set; }
        public void Initialise()
        {
            UserEvent = new HashSet<UserEvents>();
        }
    }
}
