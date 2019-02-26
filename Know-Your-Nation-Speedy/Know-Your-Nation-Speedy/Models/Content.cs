using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Content
    {
        public Content()
        {
            Initialise();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string ImageLocation { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Association { get; set; }
        public ICollection<UserRating> UserRating { get; set; }
        public ICollection<UserBookmark> UserBookmark { get; set; }

        public void Initialise()
        {
            UserRating = new HashSet<UserRating>();
            UserBookmark = new HashSet<UserBookmark>();
        }
    }
}
