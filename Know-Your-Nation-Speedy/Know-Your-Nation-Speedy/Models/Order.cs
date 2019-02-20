using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Know_Your_Nation_Speedy.Models
{
    public class Order
    {
        public Order()
        {
            Initialise();
        }
        public int Id { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateExpected { get; set; }
        public string DeliveryStreet { get; set; }
        public string DeliverySuburb { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryPostalCode { get; set; }
        public bool IsBusiness { get; set; }
        public string OrderStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

        public void Initialise()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
    }
}
