using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class Customer : IEntity<int>
    {
        [PrimaryKey] public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public Customer(int id, string name, int key)
        {
            CustomerId = id;
            CustomerName = name;
            Id = key;
        }
    }
}
