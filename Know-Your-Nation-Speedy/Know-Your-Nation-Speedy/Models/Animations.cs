using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Animations
    {
        public Animations()
        {
            Initialise();
        }

        public int AnimationsId { get; set; }
        public string AnimationName { get; set; }
        public string AnimationFileLocation { get; set; }
        public string AnimationCoverImageLocation { get; set; }
        public string AnimationDescription { get; set; }
        public ICollection<AnimationsWatched> AnimationWatched { get; set; }

        public void Initialise()
        {
            AnimationWatched = new HashSet<AnimationsWatched>();
        }
    }
}
