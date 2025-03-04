// Create a connection factory
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://zfyeenuc:94kom0sr9-KZ3C6pVqDxu3TSTH2ysU9s@woodpecker.rmq.cloudamqp.com/zfyeenuc");

// Create a connection
using IConnection connection = await factory.CreateConnectionAsync();
using IChannel channel = await connection.CreateChannelAsync();

string exhangeName = "direct-Exchange-test";
string routingKeyDirect = "direct-routing-key";


//Direct Exchange Declare
await channel.ExchangeDeclareAsync(exchange: exhangeName, ExchangeType.Direct, true, false);

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
        exchange: exhangeName,
        routingKey: routingKeyDirect,
        body: bodyMessage
    );


string bodyMessageToString = Encoding.UTF8.GetString(bodyMessage);

Console.WriteLine("Message sent successfully!");
Console.WriteLine($"Your message is " + bodyMessageToString);
Console.Read();