using Application.Values;
using AzureFunctions.Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace EnterprisyFunctions
{
    [DependencyInjectionConfig(typeof(DiConfig))]
    public static class Sample2
    {
        [FunctionName("Sample2")]
        public static IActionResult EndPoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Sample2/{order:int}")]
            HttpRequest req,
            ILogger logger,
            int order,
            [Inject] IGiveMeSomeValuesQuery query
            )
        {
            return new OkObjectResult(query.Execute((SortOrder)order));
        }
    }
}
