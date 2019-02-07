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
        public  Animations Animation{ get; set; }
        public  Users User { get; set; }
        public bool WatchedStatus { get; set; }
        public bool Bookmark { get; set; }
        public int? Rating { get; set; }
    }
}
