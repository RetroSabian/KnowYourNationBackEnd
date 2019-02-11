﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class Nations
    {
        public Nations()
        {
            Initialize();
        }

        public int NationsId { get; set; }
        public string NationName { get; set; }
        public string NationShortDescription { get; set; }
        public ICollection<Articles> Article { get; set; }

        public void Initialize()
        {
            Article = new HashSet<Articles>();
        }
    }
}
