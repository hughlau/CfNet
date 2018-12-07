using Autofac;
using CfNet.Admin.ModelFactories;
using CfNet.Core.Infrastructure.DependencyManagement;
using CfNet.Core.Infrastructure.Reflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CfNet.Admin.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<SysUserModelFactory>().As<ISysUserModelFactory>()
                .InstancePerLifetimeScope();
        }
    }
}