using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class UserBookmark
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public Content Content { get; set; }
        public User User { get; set; }
        public bool Bookmark { get; set; } = false;
    }
}
