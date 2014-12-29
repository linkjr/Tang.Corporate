using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tang.Corporate.Web.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //filterContext.RouteData.Values["Action"] = "error";
            //filterContext.Controller.ViewData.Model = new HandleErrorInfo(filterContext.Exception, "shared", "error");

            //new HomeController().Execute(filterContext.RequestContext);
            //filterContext.ExceptionHandled = true;

            //base.OnException(filterContext);
        }
    }
}