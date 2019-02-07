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
            return _db.AnimationsEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Articles> ArticlesExecute()
        {
            return _db.ArticlesEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Books> BookExecute()
        {
            return _db.BooksEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Comics> ComicExecute()
        {
            return _db.ComicsEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Donations> DonationExecute()
        {
            return _db.DonationsEntries.OrderBy(e => e.Organization).ToList();
        }
        public IList<Events> EventExecute()
        {
            return _db.EventsEntries.OrderBy(e => e.ProjectName).ToList();
        }
        public IList<Orders> OrderExecute()
        {
            return _db.OrdersEntries.OrderBy(e => e.TrackingNumber).ToList();
        }
        public IList<Products> ProductExecute()
        {
            return _db.ProductsEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Users> UserExecute()
        {
            return _db.UsersEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Nations> NationsExecute()
        {
            return _db.NationsEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Memberships> MembershipsExecute()
        {
            return _db.MembershipsEntries.OrderBy(e => e.Type).ToList();
        }
    }
}

