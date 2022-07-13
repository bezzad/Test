using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Productprice { get; set; }
        public Product(int id, string name, int price)
        {
            ProductName = name;
            ProductId = id;
            Productprice = price;
        }
    }
}
