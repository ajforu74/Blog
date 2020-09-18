using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Polly;

namespace KeyVaultConfigNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [HttpPost]
        public async Task Post()
        {
            var connectionString = Configuration.GetValue<string>("StorageConnectionString");
            var retryPolicy = Policy.Handle<StorageException>()
                .RetryAsync(2, async (ex, count, context) =>
                {
                    (Configuration as IConfigurationRoot).Reload();
                    connectionString = Configuration.GetValue<string>("StorageConnectionString");

                });
            await retryPolicy.ExecuteAsync(() => SendMessage(connectionString));

        }

        private static async Task SendMessage(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);

            storageAccount.CreateCloudQueueClient();
            var queueClient = storageAccount.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference("youtube");

            var message = new CloudQueueMessage("Hello, World");
            await queue.AddMessageAsync(message);
        }
    }
}
