using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class User
    {
        public User()
        {
            Initialise();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string UserOrganisation { get; set; }
        public DateTime MembershipExpiration { get; set; }
        public Membership Membership { get; set; }

        public ICollection<UserArticle> UserArticles { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
        public ICollection<UserComic> UserComics { get; set; }
        public ICollection<UserAnimation> UserAnimations { get; set; }
        public ICollection<Donation> Donations { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }

        public void Initialise()
        {
            UserArticles = new HashSet<UserArticle>();
            UserBooks = new HashSet<UserBook>();
            UserComics = new HashSet<UserComic>();
            UserAnimations = new HashSet<UserAnimation>();
            Donations = new HashSet<Donation>();
            Orders = new HashSet<Order>();
            UserEvents = new HashSet<UserEvent>();
        }
    }
}
