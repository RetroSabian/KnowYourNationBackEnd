using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public double DonatationAmount { get; set; }
        public DateTime DonationDate { get; set; }
        public User User { get; set; }
        public Organisation Organisation { get; set; }
    }
}
