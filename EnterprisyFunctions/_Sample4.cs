using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Person;
using Application.Values;
using AzureFunctions.Autofac;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace EnterprisyFunctions
{
    public static partial class Functions
    {
        [FunctionName(nameof(RandomlyAddingPeople))]
        public static async Task RandomlyAddingPeople(
            [TimerTrigger("0 0 0 * * *")]TimerInfo myTimer,
            TraceWriter log,
            [Inject] IAddRandomPersonCommand cmd)
        {
            var person = await cmd.Execute();
            log.Warning($"Person added was: {person.FirstName} {person.LastName}");
        }
    }
}
