using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Rabbitmq.Consumer
{
    internal class Subscriber
    {
        internal async Task Subscribe()
        {

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.Uri = new Uri("amqps://zfyeenuc:94kom0sr9-KZ3C6pVqDxu3TSTH2ysU9s@woodpecker.rmq.cloudamqp.com/zfyeenuc");

            using IConnection connection = await factory.CreateConnectionAsync();
            using IChannel channel = await connection.CreateChannelAsync();

            // Declare a queue
            await channel.QueueDeclareAsync
                (
                    queue: "demo-queue-ConsoleApp",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

            // Create a consumer
            var consumer = new AsyncEventingBasicConsumer(channel);

            // Consume the message
            consumer.ReceivedAsync += async (ch, ea) =>
            {
                string content = Encoding.UTF8.GetString(ea.Body.ToArray());

                Console.WriteLine($"Message received: {content}");

                await Task.Delay(200);

                Console.WriteLine("Message processed!");
            };

            // Start consuming
            await channel.BasicConsumeAsync(queue: "demo-queue-ConsoleApp", autoAck: true, consumer: consumer);
        }

    }
}
