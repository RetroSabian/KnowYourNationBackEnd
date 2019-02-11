﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Memberships
    {
        public Memberships()
        {
            Initialize();
        }

        public int MembershipsId { get; set; }
        public string MembershipType { get; set; }
        public DateTime MembershipDuration { get; set; }
        public double MembershipPrice { get; set; }
        public ICollection<Users> User { get; set; }

        public void Initialize()
        {
            User = new HashSet<Users>();
        }
    }
}
