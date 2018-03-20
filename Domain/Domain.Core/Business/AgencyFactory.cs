using Autofac;
using Domain.Core.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace Domain.Core.Business
{
    public static class AgencyFactory
    {
        private static Autofac.IContainer container = null;

        static AgencyFactory()
        {
            InitProviders();
        }

        private static void InitProviders()
        {
            //Initialize Builder
            var builder = new ContainerBuilder();

            //Register all classes dynamically
            builder.RegisterAssemblyTypes(typeof(PropertyMatcher).Assembly)
                   .Where(t => t.IsAssignableTo<PropertyMatcher>())
                   .Where(t => !t.IsAbstract)
                   .As<PropertyMatcher>()
                   .AsSelf()
                   .InstancePerDependency();

            //Build Container
            container = builder.Build();
        }

        public static IPropertyMatcher GetProvider(string agencyCode)
        {
            if (!container
                .Resolve<IEnumerable<PropertyMatcher>>().Any(o => o.AgencyCode.Equals(agencyCode, StringComparison.OrdinalIgnoreCase)))
            {
                return null;               
            }
            return container
                    .Resolve<IEnumerable<PropertyMatcher>>()?
                    .FirstOrDefault(o => o.AgencyCode.Equals(agencyCode, StringComparison.OrdinalIgnoreCase));

        }
    }
}
