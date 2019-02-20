using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Know_Your_Nation_Speedy.Models
{
    public class BaseProduct
    {
        public BaseProduct()
        {
            Initialise();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImageLocation { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool IsAlive { get; set; }
        public ICollection<Product> Products { get; set; }

        public void Initialise()
        {
            Products = new HashSet<Product>();
        }
    }
}
