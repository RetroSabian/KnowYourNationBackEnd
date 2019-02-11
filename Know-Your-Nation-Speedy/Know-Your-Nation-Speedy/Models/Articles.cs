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
        public string ArticleName { get; set; }
        public string ArticleFileLocation { get; set; }
        public string ArticleCoverImageLocation { get; set; }
        public string ArticleDescription { get; set; }
        public Nations Nation { get; set; }
        public ICollection<ArticlesRead> ArticleRead { get; set; }

        public void Initialise()
        {
            ArticleRead = new HashSet<ArticlesRead>();
        }
    }
}
