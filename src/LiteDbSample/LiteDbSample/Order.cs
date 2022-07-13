using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Product { get; set; }
        public Order(Customer customer, List<Product> products, int orderId)
        {
            Customer = customer;
            Product = products;
            OrderId = orderId;
        }
    }
}
