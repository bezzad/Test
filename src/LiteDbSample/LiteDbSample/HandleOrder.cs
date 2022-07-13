using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class HandleOrder
    {
        LiteDatabase db;
        List<Customer> _customerList = new List<Customer>();
        List<Product> _productList = new List<Product>();
        List<Order> _orderList = new List<Order>();
        public void CreateDB()
        {
            if (db == null)
            {
                //createDB
                db = new LiteDatabase(@"C:\Temp\MyData.db");
            }

        }
        public void InsertNewCustomer(Customer customer)
        {
            var col = db.GetCollection<Customer>("customers");
            col.Insert(customer);
            _customerList.Add(customer);
        }
        public void InsertNewProduct(Product product)
        {
            var col = db.GetCollection<Product>("products");
            col.Insert(product);
            _productList.Add(product);
        }
        public void MakeOrder(Order order)
        {
            var col = db.GetCollection<Order>("orders");
            col.Insert(order);
            _orderList.Add(order);
        }
        public LiteDatabase GetDB()
        {
            return db;
        }
        public void DeleteProduct(string productName)
        {
            var col = db.GetCollection<Product>("products");
            foreach (Product product in _productList)
            {
                if (productName == product.ProductName)
                    col.Delete(product.ProductId);
            }
        }
        public void DeleteCustomer(string customerName)
        {
            var col = db.GetCollection<Product>("customers");
            foreach (Customer customer in _customerList)
            {
                if (customerName == customer.CustomerName)
                    col.Delete(customer.CustomerId);
            }
        }
        public Product GetProduct(string productName)
        {
            var col = db.GetCollection<Product>("products");
            foreach (Product product in _productList)
            {
                if (productName == product.ProductName)
                    return product;
            }
            return null;
        }
        public Customer GetCustomer(string customerName)
        {
            var col = db.GetCollection<Product>("customers");
            foreach (Customer customer in _customerList)
            {
                if (customerName == customer.CustomerName)
                    return customer;
            }
            return null;
        }
        public void PrintOrder(int orderid)
        {
            var col = db.GetCollection<Order>("orders");
            foreach(Order order in _orderList)
            {
                if(order.OrderId == orderid)
                {
                    Console.Write(order.Customer.CustomerName);
                    foreach (Product p in order.Product)
                        Console.Write(p.ProductName);
                    Console.WriteLine();
                }       
            }
        }
    }
}
