using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : class
    {
        public static LiteDatabase _context = null;
        public ILiteCollection<TEntity> table = null;
        public GenericRepository(string collectionName)
        {
            if(_context == null)
                _context = new LiteDatabase(@"D:\Temp\MyData" + collectionName+ ".db");
            table = _context.GetCollection<TEntity>(collectionName);
        }
        public GenericRepository(LiteDatabase context, string collectionName)
        {
            _context = context;
            table = _context.GetCollection<TEntity>(collectionName);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return (IEnumerable < TEntity > )table.EntityMapper.Members.ToList();
        }
        public TEntity GetById(Tkey id)
        {
            return table.FindById(new BsonValue(id));
        }
        public void Insert(TEntity obj, Tkey id)
        {
            table.Insert(new BsonValue(id),  obj);
        }
        public void Update(TEntity obj, Tkey id)
        {
            table.Update(new BsonValue(id), obj);
        }
        public void Delete(Tkey id)
        {
            table.Delete(new BsonValue(id));
        }
        public void Save()
        {
            //??
        }
    }
}

