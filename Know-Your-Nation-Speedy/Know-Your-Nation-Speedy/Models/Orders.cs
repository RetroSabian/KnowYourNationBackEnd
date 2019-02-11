using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Orders
    {
        public Orders()
        {
            Initialise();
        }

        public int OrdersId { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateExpected { get; set; }
        public string DeliveryStreet { get; set; }
        public string DeliverySuburb { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryPostalCode { get; set; }
        public bool IsBusiness { get; set; }
        public string OrderStatus { get; set; }
        public string TrackingNumber { get; set; }
        public Users User { get; set; }
        public ICollection<ProductOrders> ProductOrder { get; set; }

        public void Initialise()
        {
            ProductOrder = new HashSet<ProductOrders>();
        }
    }
}
