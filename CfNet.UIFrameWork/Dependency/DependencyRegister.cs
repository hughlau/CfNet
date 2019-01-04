using Autofac;
using Autofac.Integration.Mvc;
using CfNet.Core.Data;
using CfNet.Core.Data.Infrastructure;
using CfNet.Core.Infrastructure.DependencyManagement;
using CfNet.Core.Infrastructure.Reflect;
using CfNet.Data.Infrastructure;
using CfNet.Service.Infrastructure.Authentication;
using CfNet.Service.SysMenuService;
using CfNet.Service.SysUserService;
using System.Linq;
using System.Reflection;
using System.Web;

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

            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new HttpContextWrapper(null) as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerLifetimeScope();

            //依赖注入 
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Service
            builder.RegisterType<SysMenuService>().As<ISysMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<SysUserService>().As<ISysUserService>().InstancePerLifetimeScope();
            builder.RegisterType<SysUserAuthService>().As<ISysUserAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<SysPageService>().As<ISysPageService>().InstancePerLifetimeScope();

            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRegistrationService>().As<IUserRegistrationService>().InstancePerLifetimeScope();



            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

        #endregion
    }
}
