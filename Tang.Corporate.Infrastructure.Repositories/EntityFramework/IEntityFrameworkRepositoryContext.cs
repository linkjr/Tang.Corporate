using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Repositories;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework
{
    /// <summary>
    /// 提供基于Microsoft Entity Framework支持的一种仓储上下文的接口。
    /// </summary>
    public interface IEntityFrameworkRepositoryContext : IRepositoryContext
    {
        /// <summary>
        /// 获取当前仓储上下文所使用的Entity Framework的<see cref="DbContext"/>实例。
        /// </summary>
        DbContext Context { get; }
    }
}
