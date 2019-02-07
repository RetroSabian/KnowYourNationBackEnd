using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class ProductOrders
    {
        public int ProductOrdersId { get; set; }
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }
        public Orders Order { get; set; }
        public Products Product{ get; set; }
        public int Quantity { get; set; }
    }
}
