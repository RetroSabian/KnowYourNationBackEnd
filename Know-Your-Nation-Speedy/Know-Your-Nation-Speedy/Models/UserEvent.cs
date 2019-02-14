using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class UserEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}
