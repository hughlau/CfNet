using Autofac;
using Autofac.Integration.Mvc;
using CfNet.Core.Data;
using CfNet.Core.Data.Infrastructure;
using CfNet.Core.Infrastructure.DependencyManagement;
using CfNet.Core.Infrastructure.Reflect;
using CfNet.Data.Infrastructure;
using CfNet.Service.SysMenuService;
using CfNet.Service.SysUserService;
using System.Linq;
using System.Reflection;

/****************************************************************
*   Author：L
*   Time：2018/11/21 16:50:03
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.UIFrameWork.Dependency
{
    public class DependencyRegister : IDependencyRegistrar
    {
        #region Field
        #endregion

        #region Ctor
        #endregion

        #region Method

        public static void Register(ContainerBuilder builder)
        {
            //依赖注入 
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Service
            builder.RegisterType<SysMenuService>().As<ISysMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<SysUserService>().As<ISysUserService>().InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerLifetimeScope();

            //依赖注入 
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Service
            builder.RegisterType<SysMenuService>().As<ISysMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<SysUserService>().As<ISysUserService>().InstancePerLifetimeScope();

            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

        #endregion
    }
}
