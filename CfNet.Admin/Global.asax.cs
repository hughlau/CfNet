using Autofac;
using Autofac.Integration.Mvc;
using CfNet.Data.Infrastructure;
using CfNet.Service.BaseService;
using CfNet.Service.SysMenuService;
using CfNet.Service.SysUserService;
using CfNet.UIFrameWork.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CfNet.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //依赖注入 
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            #region Service

            builder.RegisterType<SysMenuService>().As<ISysMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<SysUserService>().As<ISysUserService>().InstancePerLifetimeScope();

            #endregion


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            MapperRegister.Initialize();
        }
    }
}
