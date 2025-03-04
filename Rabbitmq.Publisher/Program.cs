using System;
using System.Threading.Tasks;

namespace Rabbitmq.Publisher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Publish publish = new Publish();

            await publish.MessageSenderAsync();

        }
    }
}
