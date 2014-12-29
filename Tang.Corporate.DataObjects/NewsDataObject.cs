using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.DataObjects
{
    [DataContract]
    public class NewsDataObject
    {
        /// <summary>
        /// 获取或设置新闻ID。
        /// </summary>
        [Display(Name = "新闻ID")]
        public Guid ID { get; set; }

        /// <summary>
        /// 获取或设置新闻标题。
        /// </summary>
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置封面图。
        /// </summary>
        [Display(Name = "封面图")]
        public string CoverImg { get; set; }

        /// <summary>
        /// 获取或设置新闻内容。
        /// </summary>
        [Display(Name = "内容")]
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置创建人ID。
        /// </summary>
        [Display(Name = "创建人")]
        public Guid UserID { get; set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        [Display(Name = "创建日期")]
        public DateTime CreateDate { get; set; }
    }

    [DataContract]
    public class ManageNewsDataObject
    {

    }

    [DataContract]
    public class NewsRequest
    {

    }

    [DataContract]
    public class NewsResponse
    {

    }
}
