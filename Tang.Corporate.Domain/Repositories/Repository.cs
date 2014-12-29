using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
          where TEntity : class, IAggregateRoot
    {
        public abstract void Create(TEntity entity);

        public abstract void Remove(TEntity entity);

        public abstract void Modify(TEntity entity);

        public abstract TEntity Find(object id);

        public abstract IQueryable<TEntity> FindAll();
    }
}
