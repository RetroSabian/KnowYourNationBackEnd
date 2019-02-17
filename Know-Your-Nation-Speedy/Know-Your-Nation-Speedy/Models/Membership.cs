using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Membership
    {
        public Membership()
        {
            Initialize();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool AllowArticle { get; set; } = false;
        public bool AllowAnimation { get; set; } = false;
        public bool AllowBook { get; set; } = false;
        public bool AllowComic { get; set; } = false;
        public bool IsAlive { get; set; } = false;
        public ICollection<User> Users { get; set; }

        public void Initialize()
        {
            Users = new HashSet<User>();
        }
    }
}
