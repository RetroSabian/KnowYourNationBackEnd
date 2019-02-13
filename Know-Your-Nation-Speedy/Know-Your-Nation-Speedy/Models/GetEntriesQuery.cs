using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class GetEntriesQuery
    {
        private readonly MyDbContext _db;
        public GetEntriesQuery(MyDbContext db)
        {
            _db = db;
        }

        public IList<Animation> AnimationExecute()
        {
            return _db.AnimationEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Article> ArticleExecute()
        {
            return _db.ArticleEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Book> BookExecute()
        {
            return _db.BookEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Comic> ComicExecute()
        {
            return _db.ComicEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Donation> DonationExecute()
        {
            return _db.DonationEntries.ToList();
        }
        public IList<Event> EventExecute()
        {
            return _db.EventEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Order> OrderExecute()
        {
            return _db.OrderEntries.OrderBy(e => e.TrackingNumber).ToList();
        }
        public IList<Product> ProductExecute()
        {
            return _db.ProductEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<User> UserExecute()
        {
            return _db.UserEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Nation> NationExecute()
        {
            return _db.NationEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Membership> MembershipExecute()
        {
            return _db.MembershipEntries.OrderBy(e => e.Type).ToList();
        }
        public IList<UserAnimation> UserAnimationExcecute()
        {
            return _db.UserAnimationEntries.ToList();
        }
        public IList<UserArticle> UserArticleExcecute()
        {
            return _db.UserArticleEntries.ToList();
        }
        public IList<UserBook> UserBookExecute()
        {
            return _db.UserBookEntries.ToList();
        }
        public IList<UserComic> UserComicExecute()
        {
            return _db.UserComicEntries.ToList();
        }
        public IList<ProductOrder> ProductOrderExecute()
        {
            return _db.ProductOrderEntries.ToList(); 
        }
        public IList<UserEvent> UserEventExecute()
        {
            return _db.UserEventEntries.ToList();
        }
        public IList<SpeedyCharacter> SpeedyCharacterExecute()
        {
            return _db.SpeedyCharacterEntries.ToList();
        }
        public IList<Organisation> OrganisationExecute()
        {
            return _db.OrganisationEntries.ToList();
        }
    }
}

