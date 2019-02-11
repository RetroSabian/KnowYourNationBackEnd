using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Products
    {
        public Products()
        {
            Initialise();
        }
        public int ProductsId { get; set; }
        public string ProductName { get; set; }
        public string ProductCoverImageLocation { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductRating { get; set; }
        public double ProductPrice { get; set; }
        public string ProductType { get; set; }
        public int ProductQuantityOnHand { get; set; }
        public int? ProductSizeOption { get; set; }
        public int? ProductColourOption { get; set; }
        public ICollection<ProductOrders> ProductOrder { get; set; }
        public void Initialise()
        {
            ProductOrder = new HashSet<ProductOrders>();
        }
    }
}
