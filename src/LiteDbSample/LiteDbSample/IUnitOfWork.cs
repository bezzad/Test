using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<Customer, int> customerRepository { get; }
        IGenericRepository<Product, int> productRepository { get; }
        IGenericRepository<Order, int> orderRepository { get; }

        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();

            /// <summary>
            /// Discards all changes that has not been committed
            /// </summary>
            void Rollback();

            /// <summary>
            /// Factory for a write Transaction. 
            /// Essential object to create scope for updates.
            /// </summary>
            void BeginWrite();

            void Refresh();
        
    }
}
