using System;
using Yak.Common;
using Yak.Emulator;
using Yak.Gpio;

namespace Yak.Processing
{
    public class ProcessingServer : IDisposable
    {
        private readonly Yak.Messaging.Queue queue;

        private ProcessingServer(bool useEmulator)
        {
            var log = new ConsoleLog();
            var gpio = new YakLoggingGPIO(log);
            Sherpa sherpa;
            if (useEmulator)
            {
                sherpa = new Yaksimile(gpio);
            }
            else
            {
                sherpa = new Sherpa(gpio);
            }

            sherpa.Initialize();
            this.queue = new Yak.Messaging.Queue();
            queue.SetupReceiver(sherpa);
        }

        public void Dispose()
        {
            this.queue.Dispose();
        }

        public static ProcessingServer Start(bool useEmulator)
        {            
            return new ProcessingServer(useEmulator);
        }
    }
}