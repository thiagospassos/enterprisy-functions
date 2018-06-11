using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AzureFunctions.Autofac;
using BusinessLogic;

namespace EnterprisyFunctions
{
    class DiConfig
    {
        public DiConfig()
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<ServiceOne>().As<IServiceOne>();
            });
        }
    }
}
