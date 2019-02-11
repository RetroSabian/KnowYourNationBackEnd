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

        public IList<Animations> AnimationExecute()
        {
            return _db.AnimationsEntries.OrderBy(e => e.AnimationName).ToList();
        }
        public IList<Articles> ArticlesExecute()
        {
            return _db.ArticlesEntries.OrderBy(e => e.ArticleName).ToList();
        }
        public IList<Books> BookExecute()
        {
            return _db.BooksEntries.OrderBy(e => e.BookName).ToList();
        }
        public IList<Comics> ComicExecute()
        {
            return _db.ComicsEntries.OrderBy(e => e.ComicName).ToList();
        }
        public IList<Donations> DonationExecute()
        {
            return _db.DonationsEntries.OrderBy(e => e.Organization).ToList();
        }
        public IList<Events> EventExecute()
        {
            return _db.EventsEntries.OrderBy(e => e.EventName).ToList();
        }
        public IList<Orders> OrderExecute()
        {
            return _db.OrdersEntries.OrderBy(e => e.TrackingNumber).ToList();
        }
        public IList<Products> ProductExecute()
        {
            return _db.ProductsEntries.OrderBy(e => e.ProductName).ToList();
        }
        public IList<Users> UserExecute()
        {
            return _db.UsersEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Nations> NationsExecute()
        {
            return _db.NationsEntries.OrderBy(e => e.NationName).ToList();
        }
        public IList<Memberships> MembershipsExecute()
        {
            return _db.MembershipsEntries.OrderBy(e => e.MembershipType).ToList();
        }
        public IList<AnimationsWatched> AnimationsWatchedExcecute()
        {
            return _db.AnimationsWatchedEntries.ToList();
        }
        public IList<ArticlesRead> ArticlesReadExcecute()
        {
            return _db.ArticlesReadEntries.ToList();
        }
        public IList<BooksRead> BooksReadsExecute()
        {
            return _db.BooksReadEntries.ToList();
        }
        public IList<ComicsRead> ComicsReadsExecute()
        {
            return _db.ComicsReadEntries.ToList();
        }
        public IList<ProductOrders> ProductOrdersExecute()
        {
            return _db.ProductOrdersEntries.ToList(); 
        }
        public IList<UserEvents> UserEventsExecute()
        {
            return _db.UserEventsEntries.ToList();
        }
        public IList<SpeedyCharacters> SpeedyCharactersExecute()
        {
            return _db.SpeedyCharactersEntries.ToList();
        }
        public IList<Organisations> OrganisationsExecute()
        {
            return _db.OrganisationsEntries.ToList();
        }
    }
}

