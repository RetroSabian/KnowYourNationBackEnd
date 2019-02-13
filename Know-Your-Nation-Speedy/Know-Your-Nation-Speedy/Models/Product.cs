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
        public string Name { get; set; }
        public string CoverImageLocation { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int QuantityOnHand { get; set; }
        public int? SizeOption { get; set; }
        public int? ColourOption { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }

        public void Initialise()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }
    }
}
