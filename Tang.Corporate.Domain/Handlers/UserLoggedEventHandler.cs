using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Events;

namespace Tang.Corporate.Domain.Handlers
{
    public class UserLoggedEventHandler : IDomainEventHandler<UserLoggedEvent>
    {
        public void Handle(UserLoggedEvent evnt)
        {
            throw new NotImplementedException();
        }
    }
}
