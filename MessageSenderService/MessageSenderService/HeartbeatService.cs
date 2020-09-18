using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MessageSenderService
{
    public class HeartbeatService
    {
        readonly Timer _timer;
        private QueueClient _queueClient;

        public HeartbeatService(string connectionString)
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += async (sender, eventArgs) => await SendHeartbeat();
            _queueClient = new QueueClient(connectionString, "heartbeat");
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }

        private async Task SendHeartbeat()
        {
            await _queueClient.SendMessageAsync($"Heartbeat from Windows Service {DateTime.Now}");
        }
    }
}
