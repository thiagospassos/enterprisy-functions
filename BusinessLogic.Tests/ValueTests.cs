using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Xunit;

namespace Application.Tests
{
    public class ValueTests
    {
        private readonly IMediator _mediator;

        public ValueTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            var mediatrOpenTypes = new[]
            {
                    typeof(IRequestHandler<,>),
                    typeof(INotificationHandler<>),
                };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(Application.Values.AddValueToArrayCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            // It appears Autofac returns the last registered types first
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var container = builder.Build();

            _mediator = container.Resolve<IMediator>();
        }

        [Fact]
        public void ShouldCleanUp()
        {
            Assert.Equal("thiagosobraldospassos", "Thiago Sobral dos Passos".CleanUp());
            Assert.Equal("thiagopassos", "Thiago Passos".CleanUp());
        }

        [Fact]
        public async Task ShouldReturn4Values()
        {
            var result = await _mediator.Send(new Values.AddValueToArrayCommand() { Value = "Forth Value" });

            Assert.Equal(4, result.Count);
        }
    }
}
