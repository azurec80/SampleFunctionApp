using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SampleTimerTrigger
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("%TimerInterval%")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function for interval executed at: {DateTime.Now}");
        }
    }
}
