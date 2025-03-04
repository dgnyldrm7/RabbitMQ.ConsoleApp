using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Rabbitmq.Publisher
{
    internal class Publish
    {
        public async Task MessageSenderAsync()
        {
            // Create a connection factory
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://zfyeenuc:94kom0sr9-KZ3C6pVqDxu3TSTH2ysU9s@woodpecker.rmq.cloudamqp.com/zfyeenuc");

            // Create a connection
            using IConnection connection = await factory.CreateConnectionAsync();
            using IChannel channel = await connection.CreateChannelAsync();

            // Declare a queue
            await channel.QueueDeclareAsync
                (
                    queue : "demo-queue-ConsoleApp", 
                    durable: true, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null
                );

            // Create a message with the console app
            Console.WriteLine("Enter your message: ");
            string? message = Console.ReadLine();

            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            // Convert the message to a byte array
            byte[] bodyMessage = Encoding.UTF8.GetBytes(message);

            // Publish the message to the queue
            await channel.BasicPublishAsync
                (
                    exchange: string.Empty,
                    routingKey: "demo-queue-ConsoleApp",
                    body: bodyMessage
                );

            string bodyMessageToString = Encoding.UTF8.GetString(bodyMessage);

            Console.WriteLine("Message sent successfully!");
            Console.WriteLine($"Your message is " + bodyMessageToString);
            Console.Read();

        }
    }
}
