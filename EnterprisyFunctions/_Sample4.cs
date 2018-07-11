using System;
using System.Linq;
using Application.Values;
using AzureFunctions.Autofac;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace EnterprisyFunctions
{
    [DependencyInjectionConfig(typeof(DiConfig))]
    public static class Sample4
    {
        [FunctionName("Timer")]
        public static void Run(
            [TimerTrigger("0 0 */2 * * *")]TimerInfo myTimer,
            TraceWriter log,
            [Inject] IGiveMeSomeValuesQuery query)
        {
            var values = query.Execute(SortOrder.Ascending).ToList();
            var r = new Random();
            var index = r.Next(0, values.Count - 1);
            log.Info($"Picked value this time was: {values[index]}, index: {index}");
        }
    }
}
