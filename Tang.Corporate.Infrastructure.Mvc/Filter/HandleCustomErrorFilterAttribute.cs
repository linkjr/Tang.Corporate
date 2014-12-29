using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using Tang.Corporate.Infrastructure.Exceptions;

namespace Tang.Corporate.Infrastructure.Mvc.Filter
{
    /// <summary>
    /// 表示处理自定义异常筛选器的特性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HandleCustomErrorFilterAttribute : FilterAttribute, IExceptionFilter
    {
        [ValidateInput(false)]
        public void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            if (exception != null)
            {
                #region 日志记录

                if (!(exception is ValidationException))
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "Logs/" + DateTime.Now.ToString("yyyyMMdd");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var msg = string.Format("{0}\r\n异常消息：{1}\r\n异常方法：{2}\r\n异常类型：{3}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        exception.GetBaseException().Message,
                        filterContext.Controller.GetType().FullName + "." + filterContext.Exception.TargetSite.Name,
                        exception.GetBaseException().GetType().ToString());
                    using (var sw = File.CreateText(path + "/" + DateTime.Now.ToString("HHmmssffff") + ".txt"))
                    {
                        sw.Write(msg);
                    }
                }

                #endregion

                #region 错误过滤

                var msgTmp = string.Empty;
                var context = filterContext.HttpContext;
                if (context.Request.IsAjaxRequest())
                {
                    if (exception is ValidationException)
                        msgTmp = "{0}";//如果是验证类异常，就显示异常消息
                    else
                        msgTmp = "服务器正忙，请稍后再试";
                    //msgTmp = "$.jBox.info('{0}');";

                    var objs = filterContext.Exception.TargetSite.GetCustomAttributes(typeof(HttpPostAttribute), true);
                    if (objs != null && objs.Length > 0)
                    {
                        filterContext.Result = new ContentResult
                        {
                            //Content = "window.setTimeout(function () { common.Error('" + String.Format(msgTmp, filterContext.Exception.GetBaseException().Message) + "'); }, 1000);",
                            Content = "common.Error('" + String.Format(msgTmp, filterContext.Exception.GetBaseException().Message) + "');",
                            ContentType = "application/x-javascript"
                        };
                    }
                    else
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                result = false,
                                msg = string.Format(msgTmp, exception.GetBaseException().Message)
                            }
                        };
                    }
                }
                else
                {
                    msgTmp = "异常消息：{0}<br/>异常方法：{1}<br/>异常类型：{2}";

                    //filterContext.Result = new ContentResult
                    //{
                    //    Content = String.Format(msgTmp,
                    //        exception.GetBaseException().Message,
                    //        filterContext.Controller.GetType().FullName + "." + filterContext.Exception.TargetSite.Name,
                    //        exception.GetBaseException().GetType().ToString())
                    //};

                    var ex = new Exception(String.Format(msgTmp, exception.GetBaseException().Message,
                        filterContext.Controller.GetType().FullName + "." + filterContext.Exception.TargetSite.Name, exception.GetBaseException().GetType().ToString()));
                    var controllerName = filterContext.Controller.ControllerContext.RouteData.Values["Controller"].ToString();
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "error",
                        ViewData = new ViewDataDictionary(new HandleErrorInfo(ex, controllerName, "error"))
                    };
                }

                #endregion

                filterContext.ExceptionHandled = true;
            }
        }
    }
}
