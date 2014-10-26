using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yak.Processing;

namespace Yak.Messaging
{
    class Queue: IDisposable
    {
        const string busConnectionString = "host=localhost";
        const string queueName = "yak.animation.queue";

        private IBus bus;

        public Queue()
        {
            var logger = new NullLogger();
            this.bus = RabbitHutch.CreateBus(busConnectionString, x => x.Register<IEasyNetQLogger>(_ => logger));
        }
        public void Send<T>(T message) where T:class
        {
            this.bus.Send(queueName, message);
        }

        public void Receive<T>(Action<T> onMessage) where T:class
        {
            this.bus.Receive<T>(queueName, onMessage);
        }

        internal void SetupReceiver(IBody body)
        {
            this.bus.Receive(queueName, x => x
                .Add<SetEyeColor>(sec => body.Eyes(sec.EyeColor))
                .Add<SetRifleColor>(sec => body.Rifle(sec.RifleColor))
                .Add<Wait>(wait => body.Wait(wait.Time))
            );
        }

        public void Dispose()
        {
            if (this.bus != null)
            {
                this.bus.Dispose();
                this.bus = null;
            }
        }
    }
}
