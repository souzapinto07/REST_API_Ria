using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ria.Application.Customers.Commands;
using System.IO;
using System.Threading.Tasks;

namespace Ria.API
{
    public class CustomerFunction
    {
        private readonly ILogger<CustomerFunction> _logger;

        public CustomerFunction(ILogger<CustomerFunction> logger)
        {
            _logger = logger;
        }

        [Function("Customers")]
        public IActionResult Customers([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a GET request.");
            return new OkObjectResult("Welcome to Azure Functions - GET!");
        }

        [Function("CreateCustomers")]
        public async Task<IActionResult> CreateCustomers([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a POST request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            List<CreateCustomersCommand>? data = JsonConvert.DeserializeObject<List<CreateCustomersCommand>>(requestBody);

            if (data == null)
            {
                return new BadRequestObjectResult("Invalid request body");
            }

            // Process the data as needed
             return new OkObjectResult($"Customer {data[0].FirstName} with email {data[0].LastName} created successfully!");
        }
    }
}
