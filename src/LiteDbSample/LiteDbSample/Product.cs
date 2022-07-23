using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class Product
    {
        public int Key { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Productprice { get; set; }
        public Product(int id, string name, int price, int key)
        {
            ProductName = name;
            ProductId = id;
            Productprice = price;
            Key = key;
        }
    }
}
