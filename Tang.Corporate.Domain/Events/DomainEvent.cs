using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tang.Corporate.Domain.Handlers;
using Tang.Corporate.Infrastructure.Ioc;

namespace Tang.Corporate.Domain.Events
{
    public class DomainEvent
    {
        public static void Publish<TDomainEvent>(TDomainEvent evnt)
            where TDomainEvent : class, IDomainEvent
        {
            var handlers = ServiceLocator.Instance.ResolveAll<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(evnt);
            }
        }
    }
}
