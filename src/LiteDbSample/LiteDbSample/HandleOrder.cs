using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class HandleOrder //controller
    {
        IGenericRepository<Customer, int> customerRepository;
        IGenericRepository<Product,int> productRepository;
        IGenericRepository<Order,int> orderRepository;
        List<Customer> _customerList = new List<Customer>();
        List<Product> _productList = new List<Product>();
        List<Order> _orderList = new List<Order>();
        int customerId = 0;
        int productId = 0;
        int orderId = 0;
        public HandleOrder()
        {
            this.customerRepository = new GenericRepository<Customer,int>("customers");
            this.productRepository = new GenericRepository<Product,int>("products");
            this.orderRepository = new GenericRepository<Order,int>("orders");
        }
        public void InsertNewCustomer(Customer customer)
        {
            customerRepository.Insert(customer,customerId);
            customerId++;
        }
        public void InsertNewProduct(Product product)
        {
            productRepository.Insert(product, productId);
            productId++;
        }
        public void MakeOrder(Order order)
        {
            orderRepository.Insert(order,orderId);
            orderId++;
        }
        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
            
        }
        public void DeleteCustomer(int id)
        {
            customerRepository.Delete(id);
        }
        public Product GetProduct(int id)
        {
            return productRepository.GetById(id);
        }
        public Customer GetCustomer(int id)
        {
            return customerRepository.GetById(id);
        }
        public void PrintOrder(int orderid)
        {
            var orders = orderRepository.GetAll();
            foreach(Order order in orders)
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
