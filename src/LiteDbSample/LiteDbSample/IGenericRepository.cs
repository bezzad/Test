using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public interface IGenericRepository<TEntity , Tkey>
    {
        IQueryable<TEntity> Includes(params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(Tkey id);
        void Delete(Tkey id);
        void DeleteAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity AddOrUpdate(TEntity entity);
        void Dispose();
    }
}
