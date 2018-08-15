using AzureFunctions.Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace EnterprisyFunctions
{
    public static partial class Functions
    {
        [FunctionName(nameof(Sample1))]
        public static IActionResult Sample1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger logger
            )
        {
            logger.LogInformation("Test");
            string[] array = { "Value 1", "Value 2", "Value 3" };
            return new OkObjectResult(array);
        }
    }
}
