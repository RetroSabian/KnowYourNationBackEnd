using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Memberships
    {
        public Memberships()
        {
            Initialize();
        }

        public int MembershipsId { get; set; }
        public string MembershipType { get; set; }
        public DateTime MembershipDuration { get; set; }
        public double MembershipPrice { get; set; }
        public string Description { get; set; }
        public bool AllowArticles { get; set; } = false;
        public bool AllowAnimations { get; set; } = false;
        public bool AllowBooks { get; set; } = false;
        public bool AllowComics { get; set; } = false;
        public ICollection<Users> User { get; set; }

        public void Initialize()
        {
            User = new HashSet<Users>();
        }
    }
}
