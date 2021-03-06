using Jobsity.Chatroom.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Jobsity.Chatroom.Bot.Services
{
    public class RabbitConsumer : IRabbitConsumer
    {
        private readonly ICommandProcessor commandProcessor;
        private readonly IConfiguration configuration;
        private EventingBasicConsumer consumer;
        public RabbitConsumer(ICommandProcessor commandProcessor,
            IConfiguration configuration)
        {
            this.commandProcessor = commandProcessor;
            this.configuration = configuration;
        }

        public void Consume<T>()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(configuration["RabbitConnectionString"]);
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(typeof(T).Name, true, false, false);

            consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                commandProcessor.Process(JsonSerializer.Deserialize<Command>(message));
            };

            var consumerTag = channel.BasicConsume(queue: typeof(T).Name, autoAck: true, consumer: consumer);
        }
    }
}