using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Jobsity.Chatroom.WebApi.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IConfiguration configuration;

        public RabbitMQProducer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(configuration["RabbitConnectionString"]);

            using (var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {

                channel.QueueDeclare(typeof(T).Name, true, false, false);

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: typeof(T).Name, body: body);
            }
        }
    }
}
