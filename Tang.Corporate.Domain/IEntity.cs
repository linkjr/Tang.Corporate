using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain
{
    /// <summary>
    /// 表示继承于该接口的类型是领域实体类。
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取当前领域实体类的全局唯一标识。
        /// </summary>
        Guid ID { get; }
    }
}
