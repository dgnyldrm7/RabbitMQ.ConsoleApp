using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.HostName = "localhost";
factory.Uri = new Uri("amqps://zfyeenuc:94kom0sr9-KZ3C6pVqDxu3TSTH2ysU9s@woodpecker.rmq.cloudamqp.com/zfyeenuc");

using IConnection connection = await factory.CreateConnectionAsync();
using IChannel channel = await connection.CreateChannelAsync();

//Öncelikle bir exchange tanımlanır/oluşturulur.
await channel.ExchangeDeclareAsync(exchange: "direct-Exchange-test", ExchangeType.Direct, true, false, null);

//Öncelikle bir queue tanımlanır/oluşturulur.
string randomQueue = await channel.QueueDeclareAsync();

string? route = Console.ReadLine();

if(string.IsNullOrEmpty(route))
{
    route = "direct-routing-key";
}

//Oluşturulan queue exchange ile bind edilir.
await channel.QueueBindAsync
    (
        queue: randomQueue, 
        exchange: "direct-Exchange-test", 
        routingKey: route
    );

// Create a consumer
var consumer = new AsyncEventingBasicConsumer(channel);

// Start consuming
await channel.BasicConsumeAsync(queue: randomQueue, autoAck: true, consumer: consumer);



// Consume the message
consumer.ReceivedAsync += async (ch, ea) =>
{
    string content = Encoding.UTF8.GetString(ea.Body.ToArray());

    Console.WriteLine($"Message received: {content}");

    await Task.Delay(200);

    Console.WriteLine("Message processed!");
};



Console.WriteLine("Consumer started!");
Console.ReadLine();