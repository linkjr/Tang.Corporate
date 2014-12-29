using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain.Models
{
    /// <summary>
    /// 表示新闻的领域模型。
    /// </summary>
    public class News : AggregateRoot
    {
        #region ctor

        protected News()
        {
        }

        /// <summary>
        /// 初始化 <c>News</c> 类的新实例。
        /// </summary>
        /// <param name="title">新闻标题。</param>
        /// <param name="content">新闻内容。</param>
        /// <param name="userID">新闻创建人ID。</param>
        public News(string title, string converImg, string content, Guid userID)
            : base()
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            if (title.Length > 50)
                throw new ArgumentException("out of title length 50。");
            if (string.IsNullOrEmpty(converImg))
                throw new ArgumentNullException("converimg");
            if (converImg.Length > 200)
                throw new ArgumentException("out of converimg length 200。");
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");
            if (userID == Guid.Empty)
                throw new ArgumentNullException("userID");

            this.Title = title;
            this.CoverImg = converImg;
            this.Content = content;
            this.UserID = userID;
            this.CreateDate = DateTime.Now;
        }

        #endregion

        #region Entity Properties

        /// <summary>
        /// 获取或设置新闻标题。
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 获取或设置封面图。
        /// </summary>
        public string CoverImg { get; private set; }

        /// <summary>
        /// 获取或设置新闻内容。
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 获取或设置创建人ID。
        /// </summary>
        public Guid UserID { get; private set; }

        /// <summary>
        /// 获取当前领域实体类的时间戳。
        /// </summary>
        public byte[] Timestamp { get; private set; }

        /// <summary>
        /// 获取或设置创建日期。
        /// </summary>
        public DateTime CreateDate { get; private set; }

        #endregion

        #region Public Methods

        public void Modify(string title, string converImg, string content)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            if (title.Length > 50)
                throw new ArgumentException("out of title length 50。");
            if (string.IsNullOrEmpty(converImg))
                throw new ArgumentNullException("converimg");
            if (converImg.Length > 200)
                throw new ArgumentException("out of converimg length 200。");
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");

            this.Title = title;
            this.CoverImg = converImg;
            this.Content = content;
        }

        #endregion
    }
}
