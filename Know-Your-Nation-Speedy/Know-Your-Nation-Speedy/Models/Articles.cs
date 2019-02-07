using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Articles
    {
        public Articles()
        {
            Initialise();
        }
        public int ArticlesId { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string CoverImageLocation { get; set; }
        public string Description { get; set; }
        public bool InRotation { get; set; }
        public Nations Nation { get; set; }
        public ICollection<ArticlesRead> ArticleRead { get; set; }
        public void Initialise()
        {
            ArticleRead = new HashSet<ArticlesRead>();
        }
    }
}
