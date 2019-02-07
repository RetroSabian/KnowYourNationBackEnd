using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Users
    {
        public Users()
        {
            Initialise();
        }
        public int UsersId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Memberships Membership { get; set; }

        public ICollection<ArticlesRead> ArticleRead { get; set; }
        public ICollection<BooksRead> BookRead { get; set; }
        public ICollection<ComicsRead> ComicRead { get; set; }
        public ICollection<AnimationsWatched> AnimationWatched { get; set; }
        public ICollection<Donations> Donation { get; set; }
        public ICollection<Orders> Order { get; set; }
        public ICollection<UserEvents> UserEvent { get; set; }
        public void Initialise()
        {
            ArticleRead = new HashSet<ArticlesRead>();
            BookRead = new HashSet<BooksRead>();
            ComicRead = new HashSet<ComicsRead>();
            AnimationWatched = new HashSet<AnimationsWatched>();
            Donation = new HashSet<Donations>();
            Order = new HashSet<Orders>();
            UserEvent = new HashSet<UserEvents>();
        }
    }
}
