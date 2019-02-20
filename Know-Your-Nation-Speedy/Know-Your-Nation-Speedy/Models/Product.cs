using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Product
    {
        public Product()
        {
            Initialise();
        }
        public int Id { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public int BaseProductId { get; set; }
        public BaseProduct BaseProduct { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

        public void Initialise()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
    }
}
