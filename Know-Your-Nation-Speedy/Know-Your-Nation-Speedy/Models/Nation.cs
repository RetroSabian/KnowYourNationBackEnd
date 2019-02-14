using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Nation
    {
        public Nation()
        {
            Initialize();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }

        public void Initialize()
        {
            Articles = new HashSet<Article>();
        }
    }
}
