using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class UserEvents
    {
        public int UserEventsId { get; set; }
        public int EventsId { get; set; }
        public int UsersId { get; set; }
        public Users User { get; set; }
        public Events Event { get; set; }
    }
}
