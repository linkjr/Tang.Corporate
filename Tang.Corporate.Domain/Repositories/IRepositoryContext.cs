using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Infrastructure;

namespace Tang.Corporate.Domain.Repositories
{
    /// <summary>
    /// 提供仓储上下文的基接口。
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        void Create<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        void Remove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        void Modify<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        TEntity Find<TEntity>(object id) where TEntity : class, IAggregateRoot;

        IQueryable<TEntity> Queryable<TEntity>() where TEntity : class, IAggregateRoot;
    }
}
