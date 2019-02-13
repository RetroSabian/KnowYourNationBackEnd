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

        public ICollection<UserArticle> UserArticle { get; set; }
        public ICollection<UserBook> UserBook { get; set; }
        public ICollection<UserComic> UserComic { get; set; }
        public ICollection<UserAnimation> UserAnimation { get; set; }
        public ICollection<Donation> Donation { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<UserEvent> UserEvent { get; set; }

        public void Initialise()
        {
            UserArticle = new HashSet<UserArticle>();
            UserBook = new HashSet<UserBook>();
            UserComic = new HashSet<UserComic>();
            UserAnimation = new HashSet<UserAnimation>();
            Donation = new HashSet<Donation>();
            Order = new HashSet<Order>();
            UserEvent = new HashSet<UserEvent>();
        }
    }
}
