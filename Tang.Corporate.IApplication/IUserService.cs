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
    /// 提供 <c>User</c> 的服务契约接口。
    /// </summary>
    [ServiceContract]
    public interface IUserService : IApplicationService
    {
        [OperationContract]
        UserDataObject Login(UserLoginDataObject dataObject);

        [OperationContract]
        UserDataObject FindByAccount(string account);
    }
}
