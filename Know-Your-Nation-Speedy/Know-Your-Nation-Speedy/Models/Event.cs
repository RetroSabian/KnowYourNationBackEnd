using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Event
    {
        public Event()
        {
            Initialise();
        }
        public int Id { get; set; }
        public string Name { get; set;}
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Organisation Organisation { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }

        public void Initialise()
        {
            UserEvents = new HashSet<UserEvent>();
        }
    }
}
