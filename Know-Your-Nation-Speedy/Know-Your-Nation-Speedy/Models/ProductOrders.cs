﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class ProductOrders
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order orders { get; set; }
        public Product product{ get; set; }
        public int Quantity { get; set; }
    }
}