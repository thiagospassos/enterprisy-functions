using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace AzureFunctions.Autofac
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DependencyInjectionConfigAttribute : Attribute
    {
        public Type Config { get; }

        public DependencyInjectionConfigAttribute(Type config)
        {
            Config = config;
        }
    }
}
