using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class AnimationsWatched
    {
        public int AnimationsWatchedId { get; set; }
        public int AnimationsId { get; set; }
        public int UsersId { get; set; }
        public Animations Animation{ get; set; }
        public Users User { get; set; }
        public bool AnimationWatchedStatus { get; set; }
        public bool AnimationBookmark { get; set; }
        public bool AnimationAllocated { get; set; }
        public int? AnimationRating { get; set; }
    }
}
