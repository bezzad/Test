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
        public IGenericRepository<Customer, int> customerRepository;
        IGenericRepository<Product,int> productRepository;
        IGenericRepository<Order,int> orderRepository;
        UnitOfWork unitOfWork = new UnitOfWork();
        public HandleOrder()
        {
            customerRepository = unitOfWork.customerRepository;
            productRepository = unitOfWork.productRepository;
            orderRepository = unitOfWork.orderRepository;
        }
        public void InsertNewCustomer(Customer customer)
        {
            customerRepository.Add(customer);
        }
        public void InsertNewProduct(Product product)
        {
            productRepository.Add(product);
        }
        public void MakeOrder(Order order)
        {
            orderRepository.Add(order);
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
            var orders = orderRepository.Includes();
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
        public void RefreshDB()
        {
            unitOfWork.Refresh();
        }
       
    }
}
