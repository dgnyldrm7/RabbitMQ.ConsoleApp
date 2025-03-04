using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Consumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Subscriber subscriber = new Subscriber();

            await subscriber.Subscribe();
        }
    }
}
