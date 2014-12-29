using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Infrastructure
{
    /// <summary>
    /// 释放对象的资源
    /// </summary>
    public abstract class DisposableObject : IDisposable
    {
        ~DisposableObject()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 释放当前对象的所有资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放非托管资源和托管资源（后者为可选项）。
        /// </summary>
        /// <param name="disposing">若为 <see cref="true"/>，则同时释放托管资源和非托管资源；若为 <see cref="false"/>，则仅释放非托管资源。</param>
        protected abstract void Dispose(bool disposing);
    }
}
