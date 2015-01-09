using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Events;
using Tang.Corporate.Domain.Models;
using Tang.Corporate.Domain.Repositories;

namespace Tang.Corporate.Domain.EventHandlers
{
    public class UserLoggedLogEventHandler : IDomainEventHandler<UserLoggedEvent>
    {
        private readonly IAccountLogRepository accountLogRepository;
        public UserLoggedLogEventHandler(IAccountLogRepository accountLogRepository)
        {
            this.accountLogRepository = accountLogRepository;
        }

        public void Handle(UserLoggedEvent evnt)
        {
            var entity = new AccountLog(evnt.Account, AccountOpertionType.Login);
            this.accountLogRepository.Create(entity);
        }
    }
}
