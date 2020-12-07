using System;
using RabbitMQ.Client;

namespace RabbitMQSenderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleMessage sampleMessage = new SampleMessage("info", 1, DateTime.Now, "path");
            RabbitMQSender.Send(sampleMessage, "foo.key", "Messages", ExchangeType.Fanout);
        }
    }
}
