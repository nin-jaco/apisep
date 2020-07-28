using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using ApiSep.Dal;
using ApiSep.Library.Models.dto;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ApiSep.RabbitRx
{
    class Program
    {

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            string queueName = "userQueue";
            var rabbitMqConnection = factory.CreateConnection();
            var rabbitMqChannel = rabbitMqConnection.CreateModel();

            rabbitMqChannel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            int messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
            Console.WriteLine(" Listening to the queue. This channels has {0} messages on the queue", messageCount);

            var consumer = new EventingBasicConsumer(rabbitMqChannel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var userDto = JsonSerializer.Deserialize<UserDto>(message);
                using (var context = new ApiSepContext())
                {
                    context.Users.Add(userDto.ToModel());
                    context.SaveChanges();
                }
                Console.WriteLine(" User received: " + message);
                rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
            };
            rabbitMqChannel.BasicConsume(queue: queueName,
                noAck: false,
                consumer: consumer);

            Thread.Sleep(1000 * messageCount);
            Console.WriteLine(" Connection closed, no more messages.");
            Console.ReadLine();
        }
    }
}
