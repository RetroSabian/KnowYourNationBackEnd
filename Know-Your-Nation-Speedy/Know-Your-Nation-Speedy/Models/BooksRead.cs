using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class BooksRead
    {
        public int BooksReadId { get; set; }
        public int BooksId { get; set; }
        public int UsersId { get; set; }
        public Books Book { get; set; }
        public Users User { get; set; }
        public bool BookReadStatus { get; set; }
        public bool BookBookmark { get; set; }
        public int? BookRating { get; set; }
        public bool BookAllocated { get; set; }
    }
}
