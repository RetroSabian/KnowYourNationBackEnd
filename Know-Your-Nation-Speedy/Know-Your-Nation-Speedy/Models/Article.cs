using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Article
    {
        public Article()
        {
            Initialise();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string CoverImageLocation { get; set; }
        public string Description { get; set; }
        public Nation Nation { get; set; }
        public ICollection<UserArticle> UserArticle { get; set; }

        public void Initialise()
        {
            UserArticle = new HashSet<UserArticle>();
        }
    }
}
