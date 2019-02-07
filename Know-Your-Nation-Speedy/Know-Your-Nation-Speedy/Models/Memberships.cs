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
        public string Type { get; set; }
        public DateTime Duration { get; set; }
        public double Price { get; set; }
        public ICollection<Users> User { get; set; }
        public void Initialize()
        {
            User = new HashSet<Users>();
        }
    }
}
