using Autofac;
using Autofac.Integration.Mvc;
using CfNet.Data.Infrastructure;
using CfNet.Service.SysMenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/21 16:50:03
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.UIFrameWork.Dependency
{
    public class DependencyRegister
    {
        #region Field
        #endregion

        #region Ctor
        #endregion

        #region Method

        public static void Register(ContainerBuilder builder)
        {


            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            #region Service


            builder.RegisterType<SysMenuService>().As<ISysMenuService>().InstancePerLifetimeScope();

            #endregion


            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
        }

        #endregion
    }
}
