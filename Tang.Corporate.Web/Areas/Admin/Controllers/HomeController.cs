using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tang.Corporate.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}