using AzureFunctions.Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace EnterprisyFunctions
{
    public static class Sample1
    {
        [FunctionName("Sample1")]
        public static IActionResult EndPoint(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger logger
            )
        {
            string[] array = { "Value 1", "Value 2", "Value 3" };
            return new OkObjectResult(array);
        }
    }
}
