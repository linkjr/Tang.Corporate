using System.Web;
using System.Web.Mvc;

using Tang.Corporate.Infrastructure.Mvc.Filter;

namespace Tang.Corporate.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleCustomErrorFilterAttribute(), 1);
            filters.Add(new HandleErrorAttribute(), 2);
        }
    }
}
