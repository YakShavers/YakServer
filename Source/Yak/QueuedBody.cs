using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Messaging;

namespace Yak
{
    public class QueuedBody: IBody
    {
        private readonly Messaging.Queue queue;

        public QueuedBody()
        {
            this.queue = new Messaging.Queue();
        }

        public void Eyes(Nerves.LedColor eyeColor)
        {
            queue.Send(new SetEyeColor { EyeColor = eyeColor });
        }

        public void Initialize()
        {
        }

        public void Rifle(Nerves.LedColor rifleColor)
        {
            queue.Send(new SetRifleColor { RifleColor = rifleColor });          
        }

        public void TearDown()
        {
        }

        public void Wait(int waitTime)
        {
            queue.Send(new Wait { Time = 250 });
        }
    }
}
