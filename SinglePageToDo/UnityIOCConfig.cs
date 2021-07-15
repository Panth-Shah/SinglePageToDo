using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinglePageToDo.Data;
using SinglePageToDo.Data.Repository;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using System.Data.Entity;

namespace SinglePageToDo
{
    public class UnityIOCConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbContext, SinglePageToDoDBEntities>(new PerRequestLifetimeManager());
            container.RegisterType<IMessageRepository, MessageRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}