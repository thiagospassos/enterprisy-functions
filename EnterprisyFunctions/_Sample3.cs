
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.Person;
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
    public static partial class Functions
    {
        [FunctionName(nameof(GetPeople))]
        public static async Task<IActionResult> GetPeople(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            [Inject] IGetPeopleQuery query,
            ILogger logger
            )
        {
            return new OkObjectResult(await query.Execute());
        }
    }
}
