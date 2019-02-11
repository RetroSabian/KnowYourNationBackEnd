using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class ComicsRead
    {
        public int ComicsReadId { get; set; }
        public int ComicsId { get; set; }
        public int UsersId { get; set; }
        public Comics Comic { get; set; }
        public Users User { get; set; }
        public bool ComicReadStatus { get; set; }
        public bool ComicBookmark { get; set; }
        public int? ComicRating { get; set; }
        public bool ComicAllocated { get; set; }
    }
}
