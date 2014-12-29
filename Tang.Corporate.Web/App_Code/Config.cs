using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Tang.Corporate.Web
{
    /// <summary>
    /// 表示网站基本信息配置类。
    /// </summary>
    public class Config
    {
        private static string _siteName = ConfigurationManager.AppSettings["SiteName"];

        /// <summary>
        /// 获取站点名称。
        /// </summary>
        public static string SiteName
        {
            get { return _siteName; }
        }
    }
}