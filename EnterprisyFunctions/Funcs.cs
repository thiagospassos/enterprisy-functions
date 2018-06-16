
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.Values;
using AzureFunctions.Autofac;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public static class Funcs
    {
        [FunctionName("Values")]
        public static async Task<IActionResult> Values(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            [Inject] IMediator mediator,
            ILogger logger
            )
        {
            if (req.Method == "GET")
            {
                var sort = SortOrder.Ascending;
                Enum.TryParse(req.Query["sort"], true, out sort);
                return new OkObjectResult(await mediator.Send(new AllValuesQuery { SortOrder = sort }));
            }
            if (req.Method == "POST")
            {
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                return new OkObjectResult(await mediator.Send(new AddValueToArrayCommand { Value = data?.value }));
            }
            return new BadRequestObjectResult("Invalid Method");
        }
    }
}
