using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiteDbSample
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrimaryKeyAttribute"/> class.
        /// </summary>
        public PrimaryKeyAttribute()
        {
        }
    }
    public interface IEntity<TKey> where TKey : struct
    {
        [PrimaryKey][BsonId] TKey Id { get; set; }
    }
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey>, IDisposable
        where TEntity : class, IEntity<Tkey> where Tkey : struct
    {
        private volatile bool _disposed;
        LiteRepository _dbContext;
        public GenericRepository(LiteRepository dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            if (_disposed)
                return null;

            var query = _dbContext.Query<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }

        public IQueryable<TEntity> All => _dbContext.Query<TEntity>().ToEnumerable().AsQueryable();

        public IQueryable<TEntity> Includes(params Expression<Func<TEntity, object>>[] includes)
        {
            if (_disposed)
                return null;

            var query = _dbContext.Query<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToEnumerable().AsQueryable();
        }

        public void Delete(Tkey id)
        {
            if (_disposed == false)
                _dbContext?.Delete<TEntity>(new BsonValue(id));
        }

        public void DeleteAll()
        {
            if (_disposed == false)
                _dbContext.Database.GetCollection<TEntity>().DeleteAll();
        }

        public TEntity Add(TEntity entity)
        {
            // check the current entity is not exist
            if (_disposed == false && GetById(entity.Id) == null)
                _dbContext.Insert(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (_disposed == false)
                _dbContext.Update(entity);

            return entity;
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            if (_disposed == false)
                _dbContext.Upsert(entity);

            return entity;
        }

        public TEntity GetById(Tkey id)
        {
            return _dbContext.Database.GetCollection<TEntity>().FindById(new BsonValue(id));
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            _dbContext?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}

