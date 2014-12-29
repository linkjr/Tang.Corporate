using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tang.Corporate.DataObjects;
using Tang.Corporate.IApplication;
using Tang.Corporate.Infrastructure.Mvc.Paging;

namespace Tang.Corporate.Web.Controllers
{
    public class NewsController : BaseController
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }

        //
        // GET: /News/
        public ActionResult Index(int id = 1)
        {
            var list = this._newsService.List().ToPagedList(id, 10);
            return View(list);
        }
    }
}