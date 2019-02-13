using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Animation
    {
        public Animation()
        {
            Initialise();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<UserAnimation> UserAnimations { get; set; }

        public void Initialise()
        {
            UserAnimations = new HashSet<UserAnimation>();
        }
    }
}
