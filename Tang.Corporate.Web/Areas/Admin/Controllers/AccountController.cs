using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Tang.Corporate.DataObjects;
using Tang.Corporate.IApplication;

namespace Tang.Corporate.Web.Areas.Admin.Controllers
{
    public class AccountController : AdminController
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return Redirect(FormsAuthentication.DefaultUrl);
                else
                    return Redirect(returnUrl);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(UserLoginDataObject dataObject, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                this._userService.Login(dataObject);
                FormsAuthentication.SetAuthCookie(dataObject.Account, true);

                if (Request.IsAjaxRequest())
                    return Json(new { result = true, msg = "登录成功。", url = returnUrl ?? FormsAuthentication.DefaultUrl });
                else
                {
                    if (string.IsNullOrEmpty(FormsAuthentication.DefaultUrl))
                        return RedirectToAction("index", "home");
                    else
                        return Redirect(FormsAuthentication.DefaultUrl);
                }
            }
            return View(dataObject);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}