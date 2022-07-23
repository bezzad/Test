using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public interface IGenericRepository<TEntity , Tkey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Tkey id);
        void Insert(TEntity obj,Tkey id);
        void Update(TEntity obj,Tkey id);
        void Delete(Tkey id);
        void Save();
    }
}
