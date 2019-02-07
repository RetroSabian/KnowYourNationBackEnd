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
        public string ProjectName { get; set;}
        public string  Description{ get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public ICollection<UserEvents> UserEvent { get; set; }
        public void Initialise()
        {
            UserEvent = new HashSet<UserEvents>();
        }
    }
}
