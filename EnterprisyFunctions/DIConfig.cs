using System.Reflection;
using Application;
using Application.Values;
using Autofac;
using AzureFunctions.Autofac;
using MediatR;
using MediatR.Pipeline;

namespace EnterprisyFunctions
{
    class DiConfig
    {
        public DiConfig()
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
                var mediatrOpenTypes = new[]
                {
                    typeof(IRequestHandler<,>),
                    typeof(INotificationHandler<>),
                };

                foreach (var mediatrOpenType in mediatrOpenTypes)
                {
                    builder
                        .RegisterAssemblyTypes(typeof(AddValueToArrayCommand).GetTypeInfo().Assembly)
                        .AsClosedTypesOf(mediatrOpenType)
                        .AsImplementedInterfaces();
                }
                // It appears Autofac returns the last registered types first
                builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
                builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
                //builder.RegisterGeneric(typeof(GenericRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));
                //builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
                //builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
                //builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
                //builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

                builder.Register<ServiceFactory>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
            });
        }
    }


}
