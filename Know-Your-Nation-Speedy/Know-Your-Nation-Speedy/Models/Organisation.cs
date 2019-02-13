using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Organisation
    {
        public Organisation()
        {
            Initialise();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set;}
        public ICollection<Donation> Donation { get; set; }
        public ICollection<Event> Event { get; set; }

        public void Initialise()
        {
            Donation = new HashSet<Donation>();
            Event = new HashSet<Event>();
        }
    }
}
