﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class temp
    {
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public bool ReadStatus { get; set; } = false;
        public bool Bookmark { get; set; } = false;
        public int? Rating { get; set; }
        public bool Allocated { get; set; } = false;
    
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public string ImageLocation { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Association { get; set; }
    }
}
