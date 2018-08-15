using System;
using System.Reflection;
using System.Threading.Tasks;
using Application.Person;
using Application.Values;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Xunit;
using System.Linq;

namespace Application.Tests
{
    public class PersonTests
    {
        private readonly IGetPeopleQuery _getPeopleQuery;

        public PersonTests()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(GiveMeSomeValuesQuery).GetTypeInfo().Assembly)
            .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query"))
            .AsImplementedInterfaces();

            builder.RegisterType<FunctionsDbInitializer>().AsSelf();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<FunctionsDbContext>(options => options
                .UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Transient);

            builder.Populate(serviceCollection);

            var _container = builder.Build();
            _getPeopleQuery = _container.Resolve<IGetPeopleQuery>();
            var initializer = _container.Resolve<FunctionsDbInitializer>();
            initializer.Initialize().Seed();
        }

        [Fact]
        public async Task  ShouldReturnPersons()
        {
            var list = await _getPeopleQuery.Execute();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task  ShouldHave6People()
        {
            var list = await _getPeopleQuery.Execute();
            Assert.Equal(6,list.Count());
        }

    }
}
