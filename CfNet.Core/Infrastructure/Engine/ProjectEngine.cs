using Autofac;
using Autofac.Core;
using CfNet.Core.Infrastructure.DependencyManagement;
using CfNet.Core.Infrastructure.Reflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************
*   Author：L
*   Time：2018/11/28 17:26:05
*   FrameVersion：4.6.1
*   Description：
*
*****************************************************************/
namespace CfNet.Core.Infrastructure.Engine
{
    public class ProjectEngine : IEngine
    {
        #region Field

        private Container container;

        #endregion

        #region Ctor
        #endregion

        #region Utility

        protected virtual void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //dependencies
            var typeFinder = new WebAppTypeFinder();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //register dependencies provided by other assemblies
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder, typeFinder, config);

            var container = builder.Build();
            this._containerManager = new ContainerManager(container);

            //set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion

        #region Method

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
