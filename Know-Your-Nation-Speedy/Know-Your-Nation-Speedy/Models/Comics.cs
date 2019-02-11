using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Comics
    {
        public Comics()
        {
            Initialise();
        }

        public int ComicsId { get; set; }
        public string ComicName { get; set; }
        public string ComicFileLocation { get; set; }
        public string ComicCoverImageLocation { get; set; }
        public string ComicDescription { get; set; }
        public ICollection<ComicsRead> ComicRead { get; set; }

        public void Initialise()
        {
            ComicRead = new HashSet<ComicsRead>();
        }
    } 
}
