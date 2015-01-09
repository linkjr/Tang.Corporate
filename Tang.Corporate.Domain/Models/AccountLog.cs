using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain.Models
{
    /// <summary>
    /// 表示账户日志的领域模型。
    /// </summary>
    public class AccountLog : AggregateRoot
    {
        #region ctor

        /// <summary>
        /// 获取或设置操作的账户。
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 获取或设置账户的操作类型。
        /// </summary>
        public AccountOpertionType OpertionType { get; private set; }

        /// <summary>
        /// 获取或设置账户操作的IP地址。
        /// </summary>
        public string IpAddress { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        #endregion

        protected AccountLog() { }

        public AccountLog(string account, AccountOpertionType opertionType)
        {
            this.Account = account;
            this.OpertionType = opertionType;
            this.IpAddress = string.Empty;//GetIpAddress();
            this.CreateDate = DateTime.Now;
        }
    }

    /// <summary>
    /// 指定 <c>AccountLog</c> 的操作类型。
    /// </summary>
    public enum AccountOpertionType
    {
        /// <summary>
        /// 表示注册操作。
        /// </summary>
        Register = 1,
        /// <summary>
        /// 表示登录操作
        /// </summary>
        Login,
    }
}
