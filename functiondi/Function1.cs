using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace functiondi
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [TimerTrigger("0 */1 * * * *")]TimerInfo myTimer,
            [Inject(typeof(IProcessor))]IProcessor processor,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
