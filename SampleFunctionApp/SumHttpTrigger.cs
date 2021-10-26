using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

/// <summary>
/// 
/// </summary>
namespace SampleSumHttpTrigger
{
    public static class SumHttpTrigger
    {
        /// <summary>Runs the specified req.</summary>
        /// <param name="req">The req.</param>
        /// <param name="log">The log.</param>
        /// <returns>
        ///  The sum of two whole numbers.
        /// </returns>
        [FunctionName("Sum")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string num1 = req.Query["num1"];
            string num2 = req.Query["num2"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //number1 = number1 ?? data?.number1;
            //number2 = number2 ?? data?.number2;

            string responseMessage = "";

            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                responseMessage = "Empty input. Enter two whole numbers.";
                log.LogError(responseMessage);
                return new OkObjectResult(responseMessage);
            }

            if(!num1.All(char.IsDigit) || !num2.All(char.IsDigit))
            {
                responseMessage = "Enter two valid whole numbers.";
                log.LogError(responseMessage);
                return new OkObjectResult(responseMessage);
            }

            int a = Convert.ToInt32(num1);
            int b = Convert.ToInt32(num2);

            responseMessage = $"The sum is: {(a + b)}.";
            log.LogInformation($"Request successfully processed for {num1} and {num2}.");
            return new OkObjectResult(responseMessage);
        }
    }
}
