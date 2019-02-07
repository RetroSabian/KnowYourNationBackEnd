using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Books
    {
        public Books()
        {
            Initialise();
        }
        public int BooksId { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string CoverImageLocation { get; set; }
        public string Description { get; set; }
        public ICollection<BooksRead> BookRead { get; set; }
        public void Initialise()
        {
            BookRead = new HashSet<BooksRead>();
        }
    }
}
