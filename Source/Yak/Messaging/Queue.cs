using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.Messaging
{
    class Queue
    {
        const string busConnectionString = "host=localhost";
        const string queueName = "yak.animation.queue";

        private IBus bus;

        private IBus GetBus()
        {
            if (this.bus == null)
            {
                this.bus = RabbitHutch.CreateBus(busConnectionString);
            }

            return this.bus;
        }

        public void Send<T>(T message) where T:class
        {
            GetBus().Send(queueName, message);  
        }

        public void Receive<T>(Action<T> onMessage) where T:class
        {
            GetBus().Receive<T>(queueName, onMessage);
        }

        internal void SetupReceiver(Sherpa sherpa)
        {
            GetBus().Receive(queueName, x => x
                .Add<SetEyeColor>(sec => sherpa.Eyes(sec.EyeColor))
                .Add<Wait>(wait => sherpa.Wait(wait.Time)));
        }
    }
}
