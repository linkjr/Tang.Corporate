using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain.Models
{
    /// <summary>
    /// 表示领域实体类型的基类。
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        /// 初始化 <c>Entity</c> 类的新实例。
        /// </summary>
        public Entity()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        public Guid ID { get; private set; }
    }
}
