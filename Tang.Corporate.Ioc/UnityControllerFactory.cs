using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace Tang.Corporate.Ioc
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        IUnityContainer container;
        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext reqContext,
            Type controllerType)
        {
            return container.Resolve(controllerType) as IController;
        }
    }
}
