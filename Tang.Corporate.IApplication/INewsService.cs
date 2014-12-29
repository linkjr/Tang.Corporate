using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tang.Corporate.DataObjects;

namespace Tang.Corporate.IApplication
{
    /// <summary>
    /// 提供 <c>News</c> 的服务契约接口。
    /// </summary>
    [ServiceContract]
    public interface INewsService : IApplicationService
    {
        [OperationContract]
        void Create(ManageNewsDataObject dataObject);

        [OperationContract]
        void Remove(Guid id);

        [OperationContract]
        void Modify(ManageNewsDataObject dataOjbect);

        [OperationContract]
        NewsDataObject Find(Guid id);

        [OperationContract]
        NewsDataObject Find(Guid id, Guid userID);

        /// <summary>
        /// 根据新闻搜索请求对象获取新闻的集合。
        /// </summary>
        /// <param name="request">新闻搜索请求对象。</param>
        /// <returns>返回新闻的响应对象。</returns>
        [OperationContract]
        NewsResponse List(NewsRequest request);

        IQueryable<NewsDataObject> List();

        [OperationContract]
        IList<NewsDataObject> List(int count);
    }
}
