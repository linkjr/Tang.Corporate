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
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// 获取或设置新闻标题。
        /// </summary>
        [Display(Name = "标题")]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置封面图。
        /// </summary>
        [Display(Name = "封面图")]
        [DataMember]
        public string CoverImg { get; set; }

        /// <summary>
        /// 获取或设置新闻内容。
        /// </summary>
        [Display(Name = "内容")]
        [DataMember]
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置创建人ID。
        /// </summary>
        [Display(Name = "创建人")]
        [DataMember]
        public Guid UserID { get; set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        [Display(Name = "创建日期")]
        [DataMember]
        public DateTime CreateDate { get; set; }
    }

    [DataContract]
    public class ManageNewsDataObject
    {
        /// <summary>
        /// 获取或设置新闻ID。
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// 获取或设置新闻标题。
        /// </summary>
        [Display(Name = "标题")]
        [Required(ErrorMessage = "{0} 不能为空。")]
        [StringLength(50, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置封面图。
        /// </summary>
        [Display(Name = "封面图")]
        [Required(ErrorMessage = "{0} 不能为空。")]
        [StringLength(200, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string ConverImg { get; set; }

        /// <summary>
        /// 获取或设置视频地址。
        /// </summary>
        [Display(Name = "视频地址")]
        [StringLength(200, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string VideoUrl { get; set; }

        /// <summary>
        /// 获取或设置新闻内容。
        /// </summary>
        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0} 不能为空。")]
        [DataMember]
        public string Content { get; set; }
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
