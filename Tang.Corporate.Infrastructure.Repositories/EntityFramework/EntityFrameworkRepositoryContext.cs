using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Repositories;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext
    {
        private readonly DbContext _context;

        #region Properties

        public DbContext Context
        {
            get { return this._context; }
        }

        #endregion

        #region ctor

        public EntityFrameworkRepositoryContext()
        {
            this._context = new CorporateDbContext();
        }

        #endregion

        #region RepositoryContext Members

        public override void Create<TEntity>(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Added;
        }

        public override void Remove<TEntity>(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Modify<TEntity>(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public override TEntity Find<TEntity>(object id)
        {
            var entity = this.Context.Set<TEntity>().Find(id);
            //if (entity != default(TEntity))
            //    this.Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public override IQueryable<TEntity> Queryable<TEntity>()
        {
            return this.Context.Set<TEntity>();
        }

        public override void Commit()
        {
            var i = this.Context.SaveChanges();
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 释放对象的资源

        /// <summary>
        /// 释放非托管资源和托管资源（后者为可选项）。
        /// </summary>
        /// <param name="disposing">若为 <see cref="true"/>，则同时释放托管资源和非托管资源；若为 <see cref="false"/>，则仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                    this.Context.Dispose();
            }
        }

        #endregion
    }
}
