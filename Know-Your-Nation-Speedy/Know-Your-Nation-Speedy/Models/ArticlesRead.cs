using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class ArticlesRead
    {
        public int ArticlesReadId { get; set; }
        public int ArticlesId { get; set; }
        public int UsersId { get; set; }
        public Articles Article { get; set; }
        public  Users User { get; set; }
        public bool ReadStatus { get; set; }
        public bool Bookmark { get; set; }
        public bool GivenStatus { get; set; }
        public int? Rating { get; set; }
    }
}
