using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Infrastructure;

namespace Tang.Corporate.Domain.Repositories
{
    /// <summary>
    /// 表示仓储上下文的基类。
    /// </summary>
    public abstract class RepositoryContext : DisposableObject, IRepositoryContext
    {
        public abstract void Create<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        public abstract void Remove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        public abstract void Modify<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        public abstract TEntity Find<TEntity>(object id) where TEntity : class, IAggregateRoot;

        public abstract IQueryable<TEntity> Queryable<TEntity>() where TEntity : class, IAggregateRoot;

        /// <summary>
        /// 提交事务。
        /// </summary>
        public abstract void Commit();

        /// <summary>
        /// 回滚事务。
        /// </summary>
        public abstract void Rollback();
    }
}
