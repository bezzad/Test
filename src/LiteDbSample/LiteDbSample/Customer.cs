using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public Customer(int id, string name)
        {
            CustomerId = id;
            CustomerName = name;
        }
    }
}
