using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Tang.Corporate.Infrastructure.Ioc
{
    public class ServiceLocator : IServiceProvider
    {
        //private static readonly object obj = new object();
        private static IUnityContainer container;
        private static readonly ServiceLocator instance = new ServiceLocator();

        public IUnityContainer Container
        {
            get { return container; }
        }

        public ServiceLocator()
        {
            container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            //.AddNewExtension<Interception>();
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
            return container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            try
            {
                return container.ResolveAll<T>();
            }
            catch
            {
                return null;
            }
        }

        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }
    }
}
