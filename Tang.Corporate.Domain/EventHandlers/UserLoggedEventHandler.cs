using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Events;
using Tang.Corporate.Domain.Models;

namespace Tang.Corporate.Domain.EventHandlers
{
    public class UserLoggedEventHandler : IDomainEventHandler<UserLoggedEvent>
    {
        public UserLoggedEventHandler()
        {

        }

        public void Handle(UserLoggedEvent evnt)
        {
            //var entity = evnt.Source as User;
            //if (entity.Account == evnt.Account && entity.Password == evnt.Password)
            //{
            //}
        }
    }
}
