using System;
using Yak.Common;
using Yak.Emulator;
using Yak.Nerves;

namespace Yak.Processing
{
    public class ProcessingServer : IDisposable
    {
        private readonly Yak.Messaging.Queue queue;
        private readonly IBody body;

        private ProcessingServer(bool useEmulator)
        {
            var log = new ConsoleLog();
            var gpio = new LoggingYakNerves(log);
            IBody baseBody;
            if (useEmulator)
            {
                baseBody = new Yaksimile(gpio);
            }
            else
            {
                baseBody = new Body(gpio);
            }

            this.body = new CompositeBody(new[] 
            {
                new LoggingBody("Processing "), 
                //baseBody 
            });

            this.body.Initialize();
            this.queue = new Yak.Messaging.Queue();
            queue.SetupReceiver(this.body);
           
        }

        public void Dispose()
        {
            this.queue.Dispose();
            this.body.TearDown();
        }

        public static ProcessingServer Start(bool useEmulator)
        {            
            return new ProcessingServer(useEmulator);
        }
    }
}