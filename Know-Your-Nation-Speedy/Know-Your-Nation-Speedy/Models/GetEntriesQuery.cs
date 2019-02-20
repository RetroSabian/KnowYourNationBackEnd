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

        public IList<Content> AnimationExecute()
        {
            return _db.ContentEntries.OrderBy(e => e.Name).ToList();
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
            return _db.OrderEntries.ToList();
        }
        public IList<Product> ProductExecute()
        {
            return _db.ProductEntries.ToList();
        }
        public IList<User> UserExecute()
        {
            return _db.UserEntries.OrderBy(e => e.Name).ToList();
        }
        public IList<Membership> MembershipExecute()
        {
            return _db.MembershipEntries.OrderBy(e => e.Type).ToList();
        }
        public IList<UserContent> UserAnimationExcecute()
        {
            return _db.UserContentEntries.ToList();
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

