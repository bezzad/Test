using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            var te = new HandleOrder();
            var p1 = new Product(12, "p1", 100,1);
            var p2 = new Product(22, "p2", 300,2);
            var c1 = new Customer(23, "c1",3);
            var c2 = new Customer(24, "c2",4);
            List<Product> lp = new List<Product>();
            lp.Add(p1);
            lp.Add(p2);
            te.InsertNewProduct(p1);
            te.InsertNewProduct(p2);
            te.InsertNewCustomer(c1);
            te.InsertNewCustomer(c2);
            te.MakeOrder(new Order(c1, lp,25,5));
            te.MakeOrder(new Order(c2, lp,26,6));
            te.PrintOrder(25);
            te.PrintOrder(26);
            te.DeleteCustomer(3);
            te.DeleteCustomer(4);
            te.DeleteProduct(1);
            te.DeleteProduct(2);
        }
        
    }
}
