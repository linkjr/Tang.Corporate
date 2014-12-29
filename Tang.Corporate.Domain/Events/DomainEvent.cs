using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Tang.Corporate.Domain.Handlers;

namespace Tang.Corporate.Domain.Events
{
    public class DomainEvent
    {
        public static void Publish<TDomainEvent>(TDomainEvent evnt)
            where TDomainEvent : class, IDomainEvent
        {
            var handlers = new UnityContainer().ResolveAll<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(evnt);
            }
        }
    }
}
