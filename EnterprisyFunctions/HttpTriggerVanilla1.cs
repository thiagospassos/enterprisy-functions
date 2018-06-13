
using System.IO;
using AzureFunctions.Autofac;
using BusinessLogic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;


namespace EnterprisyFunctions
{
    [DependencyInjectionConfig(typeof(DiConfig))]
    public static class HttpTriggerVanilla1
    {
        [FunctionName("HttpTriggerVanilla1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            TraceWriter log,
            [Inject] IMediator mediator
            )
        {
            return new OkObjectResult(mediator.Send(new ServiceOne { Param1 = "Testing" }).GetAwaiter().GetResult());
        }
    }
}
