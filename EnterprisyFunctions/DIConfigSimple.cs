using System.Reflection;
using Application;
using Application.Values;
using Autofac;
using AzureFunctions.Autofac;
using MediatR;
using MediatR.Pipeline;

namespace EnterprisyFunctions
{
    class DiConfigSimple
    {
        public DiConfigSimple()
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterAssemblyTypes(typeof(AddValueToArrayCommand).GetTypeInfo().Assembly)
                    .AsImplementedInterfaces();
            });
        }
    }


}
