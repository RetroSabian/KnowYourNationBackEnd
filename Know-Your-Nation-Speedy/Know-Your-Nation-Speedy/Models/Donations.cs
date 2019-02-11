using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Donations
    {
        public int DonationsId { get; set; }
        public string Organization { get; set; }
        public double DonatationAmount { get; set; }
        public string OrganizationUrl { get; set; }
        public DateTime DonationDate { get; set; }
        public Users User { get; set; }
        public Organisations Organisation { get; set; }
    }
}
