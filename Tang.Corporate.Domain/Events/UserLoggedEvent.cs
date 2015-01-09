using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tang.Corporate.Domain.Events
{
    public class UserLoggedEvent : DomainEvent
    {
        public UserLoggedEvent(IEntity source) : base(source) { }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}
