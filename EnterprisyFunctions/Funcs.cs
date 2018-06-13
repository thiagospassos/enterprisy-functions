
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
using Newtonsoft.Json;
using Serilog;


namespace EnterprisyFunctions
{
    [DependencyInjectionConfig(typeof(DiConfig))]
    public static class Funcs
    {
        [FunctionName("CrashAndLog")]
        public static IActionResult CrashAndLog([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req,
            [Inject] IMediator mediator,
            [Inject] ILogger logger
            )
        {
            var result = mediator.Send(new ServiceOne { Param1 = "Testing" }).GetAwaiter().GetResult();

            var rand = new Random();
            var number = rand.Next(5);
            if (number == 3)
            {
                logger
                    .ForContext("Result", result, true)
                    .Error("Randomly crashing");
                throw new Exception();
            }
            return new OkObjectResult(result);
        }
    }
}
