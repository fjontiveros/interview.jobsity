using Jobsity.Chatroom.Bot.Services;
using Jobsity.Chatroom.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Jobsity.Chatroom.Bot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitConsumer rabbitConsumer;

        public Worker(ILogger<Worker> logger,
            IRabbitConsumer rabbitConsumer)
        {
            _logger = logger;
            this.rabbitConsumer = rabbitConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            rabbitConsumer.Consume<Command>();
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}