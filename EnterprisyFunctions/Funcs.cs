
using System;
using System.Security.Claims;
using AzureFunctions.Autofac;
using BusinessLogic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace EnterprisyFunctions
{
    [DependencyInjectionConfig(typeof(DiConfig))]
    public static class Funcs
    {
        [FunctionName("CrashAndLog")]
        public static IActionResult CrashAndLog([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            [Inject] IMediator mediator,
            ILogger logger
            )
        {
            var result = mediator.Send(new ServiceOne { Param1 = "From VSTS" }).GetAwaiter().GetResult();

            AuthInfo auth = null;
            try
            {
                auth = req.GetAuthInfoAsync().GetAwaiter().GetResult();
            }
            catch
            {
                //todo: nothing for now
            }

            var rand = new Random();
            var number = rand.Next(5);
            if (number == 3)
            {
                logger
                    .LogError("Randomly crashing {@result}",result);
                throw new Exception();
            }
            return new OkObjectResult(new
            {
                result,
                auth
            });
        }
    }
}
