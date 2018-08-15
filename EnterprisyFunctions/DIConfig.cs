using System;
using System.Reflection;
using Application.Values;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureFunctions.Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace EnterprisyFunctions
{
    class DiConfig
    {
        public DiConfig()
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterAssemblyTypes(typeof(GiveMeSomeValuesQuery).GetTypeInfo().Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query"))
                .AsImplementedInterfaces();

                builder.RegisterType<FunctionsDbInitializer>().AsSelf();

                var serviceCollection = new ServiceCollection();

                serviceCollection.AddDbContext<FunctionsDbContext>(options => options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Transient);

                builder.Populate(serviceCollection);
            });

            var functionsDbInitializer = DependencyInjection.Resolve(typeof(FunctionsDbInitializer), "") as FunctionsDbInitializer;
            functionsDbInitializer?.Initialize();
        }
    }
}
