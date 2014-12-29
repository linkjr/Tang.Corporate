using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain;
using Tang.Corporate.Domain.Repositories;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework
{
    public abstract class EntityFrameworkRepository<TEntity> : Repository<TEntity>
         where TEntity : class, IAggregateRoot
    {
        public IEntityFrameworkRepositoryContext Context { get; set; }

        public EntityFrameworkRepository(IRepositoryContext context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this.Context = context as IEntityFrameworkRepositoryContext; ;
        }

        public override void Create(TEntity entity)
        {
            this.Context.Create(entity);
        }

        public override void Remove(TEntity entity)
        {
            this.Context.Remove(entity);
        }

        public override void Modify(TEntity entity)
        {
            this.Context.Modify(entity);
        }

        public override TEntity Find(object id)
        {
            return this.Context.Find<TEntity>(id);
        }

        public override IQueryable<TEntity> FindAll()
        {
            return this.Context.Queryable<TEntity>();
        }
    }
}
