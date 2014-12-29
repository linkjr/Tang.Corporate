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
    public class UserDataObject
    {
        /// <summary>
        /// 获取或设置用户ID。
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// 获取或设置账户。
        /// </summary>
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置新闻创建日期。
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }
    }

    [DataContract]
    public class UserLoginDataObject
    {
        /// <summary>
        /// 获取或设置账户。
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0} 不能为空。")]
        [StringLength(50, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0} 不能为空。")]
        [StringLength(100, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string Password { get; set; }
    }
}
