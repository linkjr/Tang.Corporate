using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Events;
using Tang.Corporate.Infrastructure.Exceptions;

namespace Tang.Corporate.Domain.Models
{
    /// <summary>
    /// 表示用户的领域模型。
    /// </summary>
    public class User : AggregateRoot
    {
        /// <summary>
        /// 获取或设置账户。
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 获取或设置登录次数。
        /// </summary>
        public int LoginCount { get; private set; }

        /// <summary>
        /// 获取或设置最后一次登录日期。
        /// </summary>
        public DateTime? LastLoginDate { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        public void Login(string account, string password)
        {
            if (this.Account == account && this.Password == password)
            {
                this.LoginCount += 1;
                this.LastLoginDate = DateTime.Now;

                DomainEvent.Publish<UserLoggedEvent>(new UserLoggedEvent(this)
                {
                    Account = account,
                    Password = password
                });
            }
            else
            {
                throw new ValidationException("用户名或者密码错误。");
            }
        }
    }
}
