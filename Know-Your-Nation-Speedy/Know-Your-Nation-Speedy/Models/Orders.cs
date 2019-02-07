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
        public string TrackingNumber { get; set; }
        public string AddressToDeliever { get; set; }
        public Users User { get; set; }
        public ICollection<ProductOrders> ProductOrder { get; set; }
        public void Initialise()
        {
            ProductOrder = new HashSet<ProductOrders>();
        }
    }
}
