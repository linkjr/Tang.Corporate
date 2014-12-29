using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Events;

namespace Tang.Corporate.Domain.Handlers
{
    public interface IEventHandler<in TEvent>
        where TEvent : class, IEvent
    {
        void Handle(TEvent evnt);
    }
}
