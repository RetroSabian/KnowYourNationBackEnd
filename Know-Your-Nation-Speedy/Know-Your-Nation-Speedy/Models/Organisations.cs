using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Organisations
    {
        public Organisations()
        {
            Initialise();
        }

        public int OrganisationsId { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationDescription { get; set; }
        public string OrganisationURL { get; set;}
        public ICollection<Donations> Donation { get; set; }
        public ICollection<Events> Event { get; set; }

        public void Initialise()
        {
            Donation = new HashSet<Donations>();
            Event = new HashSet<Events>();
        }
    }
}
