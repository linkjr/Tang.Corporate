using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Tang.Corporate.Infrastructure.Ioc;
using Tang.Corporate.Ioc;
using Tang.Corporate.Web.Controllers;

namespace Tang.Corporate.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterTypeBuilder.Initialize();
            DependencyResolver.SetResolver(new UnityDependencyResolver(ServiceLocator.Instance.Container));
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(EngineContext.Current.ContainerManager.Container.Container as UnityContainer);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpStatusCode = exception is HttpException ? (exception as HttpException).GetHttpCode() : 500;
            var routeData = new RouteData();
            routeData.Values.Add("controller", "home");
            var model = new HandleErrorInfo(exception, routeData.Values["controller"].ToString(), "error");
            switch (httpStatusCode)
            {
                case 404:
                    routeData.Values.Add("action", "error");
                    break;
                default:
                    routeData.Values.Add("action", "error");
                    break;
            }
            Server.ClearError();
            var controller = new BaseController();
            controller.ViewData.Model = model;
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(this.Context), routeData));
        }
    }
}
