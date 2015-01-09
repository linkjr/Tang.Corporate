using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Models;

namespace Tang.Corporate.Infrastructure.Repositories.EntityFramework.EntityTypeConfigurations
{
    /// <summary>
    /// 表示对 <c>AccountLog</c> 领域模型的实体类型配置。
    /// </summary>
    public class AccountLogEntityTypeConfiguration : EntityTypeConfiguration<AccountLog>
    {
        /// <summary>
        /// 初始化 <c>AccountLogEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public AccountLogEntityTypeConfiguration()
        {
            base.Property(m => m.Account)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
            base.Property(m => m.IpAddress)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
