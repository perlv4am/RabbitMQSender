using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQSenderExample
{
    public class RabbitMQSender
    {
        public static ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest", VirtualHost = "/", Port = 5672 };

        public static void Send(Object message, string routingKey, string exchange, string type)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchange, type: type);
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: exchange,
                    routingKey: routingKey,
                    basicProperties: null,
                    body: body);
            }
        }
    }
}