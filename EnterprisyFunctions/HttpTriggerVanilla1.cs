
using System;
using System.IO;
using AzureFunctions.Autofac;
using BusinessLogic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
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
            [Inject] IMediator mediator,
            ILogger logger
            )
        {
            return new OkObjectResult(mediator.Send(new ServiceOne { Param1 = "Testing" }).GetAwaiter().GetResult());
        }

        [FunctionName("CrashAndLog")]
        public static IActionResult CrashAndLog([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            [Inject] IMediator mediator,
            ILogger logger
            )
        {
            var result = mediator.Send(new ServiceOne { Param1 = "Testing" }).GetAwaiter().GetResult();

            var rand = new Random();
            var number = rand.Next(5);
            if (number == 3)
            {
                logger.LogError("Randomly crashing {@result}", result);
                throw new Exception("Randomly crashing");
            }
            return new OkObjectResult(result);
        }
    }
}
