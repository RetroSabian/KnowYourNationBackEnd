using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class UserBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public bool ReadStatus { get; set; } = false;
        public bool Bookmark { get; set; }  = false;
        public int? Rating { get; set; }
        public bool Allocated { get; set; } = false;
    }
}
