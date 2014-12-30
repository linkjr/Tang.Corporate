using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Tang.Corporate.Infrastructure.Ioc
{
    public class ServiceLocator : IServiceProvider
    {
        //private static readonly object obj = new object();
        private static readonly ServiceLocator instance = new ServiceLocator();
        private readonly IUnityContainer container;

        public ServiceLocator()
        {
            this.container = new UnityContainer()
                .AddNewExtension<Interception>();
        }

        /// <summary>
        /// Gets the singleton instance of the <c>ServiceLocator</c> class.
        /// </summary>
        public static ServiceLocator Instance
        {
            get { return instance; }
        }

        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            try
            {
                return this.container.ResolveAll<T>();
            }
            catch
            {
                return null;
            }
        }

        public object GetService(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }
    }
}
