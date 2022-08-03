using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LiteRepository _dbContext;
        public UnitOfWork()
        {
            LiteDatabase s = new LiteDatabase(@"C:\Temp\MyData.db");
            _dbContext = new LiteRepository(s);
        }
        public IGenericRepository<Customer, int> customerRepository => new GenericRepository<Customer,int>(_dbContext);

        public IGenericRepository<Product, int> productRepository => new GenericRepository<Product,int>(_dbContext);

        public IGenericRepository<Order, int> orderRepository => new GenericRepository<Order,int>(_dbContext);

        public void BeginWrite()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            _dbContext?.Database?.Checkpoint();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
