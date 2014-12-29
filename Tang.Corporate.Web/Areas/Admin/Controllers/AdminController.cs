using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tang.Corporate.DataObjects;
using Tang.Corporate.Web.Controllers;

namespace Tang.Corporate.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public UserDataObject CurrentUser
        {
            get
            {
                var id = User.Identity.Name;
                return new UserDataObject
                {
                    ID = new Guid(id)
                };
            }
        }
	}
}