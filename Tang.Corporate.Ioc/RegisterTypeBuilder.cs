﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

using Tang.Corporate.Domain.Repositories;
using Tang.Corporate.IApplication;

namespace Tang.Corporate.Ioc
{
    public class RegisterTypeBuilder
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            RegisterApplicationType(container, "Tang.Corporate.Application");
            RegisterRepositoryType(container, "Tang.Corporate.Infrastructure.Repositories");
            RegisterRepositoryContextType(container, "Tang.Corporate.Infrastructure.Repositories");
            //container.RegisterType<System.Web.Mvc.IControllerFactory, UnityControllerFactory>();
            return container;
        }

        public static void RegisterApplicationType(IUnityContainer container, string toAssemblyString)
        {
            var iServiceTypes = from m in typeof(IApplicationService).Assembly.GetTypes()
                                where typeof(IApplicationService).IsAssignableFrom(m) && m.IsInterface
                                select m;
            foreach (var iType in iServiceTypes)
            {
                var serviceTypes = from m in Assembly.Load(toAssemblyString).GetTypes()
                                   where iType.IsAssignableFrom(m) && m.IsClass
                                   select m;
                foreach (var cType in serviceTypes)
                {
                    container.RegisterType(iType, cType);
                }
            }
        }

        public static void RegisterRepositoryType(IUnityContainer container, string toAssemblyString)
        {
            var iServiceTypes = from m in typeof(IRepository<>).Assembly.GetTypes()
                                where m.GetInterfaces().Any(i =>
                                    i.IsGenericType &&
                                    i.GetGenericTypeDefinition() == typeof(IRepository<>)
                                    ) && m.IsInterface
                                select m;
            foreach (var iType in iServiceTypes)
            {
                var serviceTypes = from m in Assembly.Load(toAssemblyString).GetTypes()
                                   where iType.IsAssignableFrom(m) && m.IsClass
                                   select m;
                foreach (var cType in serviceTypes)
                {
                    container.RegisterType(iType, cType);
                }
            }
        }

        public static void RegisterRepositoryContextType(IUnityContainer container, string toAssemblyString)
        {
            var iServiceTypes = from m in typeof(IRepositoryContext).Assembly.GetTypes()
                                where typeof(IRepositoryContext).IsAssignableFrom(m) && m.IsInterface
                                select m;
            foreach (var iType in iServiceTypes)
            {
                var serviceTypes = from m in Assembly.Load(toAssemblyString).GetTypes()
                                   where iType.IsAssignableFrom(m) && m.IsClass
                                   select m;
                foreach (var cType in serviceTypes)
                {
                    container.RegisterType(iType, cType);
                    container.RegisterType(cType, new UnityPerRequestLifetimeManager());
                }
            }
        }
    }
}