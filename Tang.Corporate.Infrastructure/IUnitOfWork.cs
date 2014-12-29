using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Infrastructure
{
    /// <summary>
    /// 表示所有继承于该接口的类型都是 <c>Unit Of Work</c> 的一种实现。
    /// </summary>
    /// <remarks>有关 <c>Unit Of Work</c> 的详细信息，请参见UnitOfWork模式：<seealso cref="http://martinfowler.com/eaaCatalog/unitOfWork.html。"/></remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交当前的事务。
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚当前的事务。
        /// </summary>
        void Rollback();
    }
}
