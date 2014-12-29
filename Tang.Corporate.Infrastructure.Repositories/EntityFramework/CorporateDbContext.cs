using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Models;
using Tang.Corporate.Infrastructure.Repositories.EntityFramework.EntityTypeConfigurations;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework
{
    /// <summary>
    /// 表示数据访问上下文类。
    /// </summary>
    public class CorporateDbContext : DbContext
    {
        /// <summary>
        /// 初始化 <c>CorporateDbContext</c> 类的新实例。
        /// </summary>
        public CorporateDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CorporateDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new NewsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
