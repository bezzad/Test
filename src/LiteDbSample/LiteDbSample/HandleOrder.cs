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
        UnitOfWork unitOfWork = new UnitOfWork();
        public HandleOrder()
        {
        }
        public void InsertNewCustomer(Customer customer)
        {
            unitOfWork.customerRepository.Add(customer);
        }
        public void InsertNewProduct(Product product)
        {
            unitOfWork.productRepository.Add(product);
        }
        public void MakeOrder(Order order)
        {
            unitOfWork.orderRepository.Add(order);
        }
        public void DeleteProduct(int id)
        {
            unitOfWork.productRepository.Delete(id);
            
        }
        public void DeleteCustomer(int id)
        {
            unitOfWork.customerRepository.Delete(id);
        }
        public Product GetProduct(int id)
        {
            return unitOfWork.productRepository.GetById(id);
        }
        public Customer GetCustomer(int id)
        {
            return unitOfWork.customerRepository.GetById(id);
        }
        public void PrintOrder(int orderid)
        {
            var orders = unitOfWork.orderRepository.Includes();
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
