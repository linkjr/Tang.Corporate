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
    /// 表示对 <c>News</c> 领域模型的实体类型配置。
    /// </summary>
    public class NewsEntityTypeConfiguration : EntityTypeConfiguration<News>
    {
        /// <summary>
        /// 初始化 <c>NewsEntityTypeConfiguration</c> 类的新实例。
        /// </summary>
        public NewsEntityTypeConfiguration()
        {
            base.Property(m => m.Title)
                .HasMaxLength(50)
                .IsRequired();
            base.Property(m => m.CoverImg)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();
            base.Property(m => m.Content)
                .IsRequired();
        }
    }
}
