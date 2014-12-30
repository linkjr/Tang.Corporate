using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Practices.Unity;

namespace Tang.Corporate.Infrastructure.Ioc
{
    public class UnityPerRequestLifetimeManager : LifetimeManager
    {
        private readonly string key = Guid.NewGuid().ToString();

        public UnityPerRequestLifetimeManager()
        { }

        public override object GetValue()
        {
            object result;
            if (HttpContext.Current != null)
            {
                result = HttpContext.Current.Items[key];
            }
            else
            {
                result = CallContext.GetData(key);
            }
            return result;
        }

        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[key] != null)
                    HttpContext.Current.Items.Remove(key);
            }
            else
                CallContext.FreeNamedDataSlot(key);
        }

        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Add(key, newValue);
            else
                CallContext.SetData(key, newValue);
        }
    }
}
