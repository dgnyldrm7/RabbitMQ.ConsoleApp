using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.HostName = "localhost";
factory.Uri = new Uri("amqps://zfyeenuc:94kom0sr9-KZ3C6pVqDxu3TSTH2ysU9s@woodpecker.rmq.cloudamqp.com/zfyeenuc");

using IConnection connection = await factory.CreateConnectionAsync();
using IChannel channel = await connection.CreateChannelAsync();


//Random bir kuyruk oluşturuyoruz. İsimlendirme için RabbitMq'ya bırakıyoruz.
QueueDeclareOk randomQueue = await channel.QueueDeclareAsync();

string randomQueueName = randomQueue.QueueName;

//Yukarıda tanımladığımız kuyruğu exchange'imizle eşleştiriyoruz.
await channel.QueueBindAsync(queue: randomQueueName, exchange: "fanout-Exchange-test", routingKey: string.Empty, arguments: null);

await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);


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
await channel.BasicConsumeAsync(queue: randomQueueName, autoAck: true, consumer: consumer);

Console.WriteLine("Consumer started!");
Console.ReadLine();