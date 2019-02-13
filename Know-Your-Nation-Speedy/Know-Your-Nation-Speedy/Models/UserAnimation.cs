using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class UserAnimation
    {
        public int Id { get; set; }
        public int AnimationId { get; set; }
        public int UserId { get; set; }
        public Animation Animation{ get; set; }
        public User User { get; set; }
        public bool WatchedStatus { get; set; } = false;
        public bool Bookmark { get; set; } = false;
        public bool Allocated { get; set; } = false;
        public int? Rating { get; set; }
    }
}
