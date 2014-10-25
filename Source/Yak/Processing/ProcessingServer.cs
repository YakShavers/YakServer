using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Common;
using Yak.Emulator;
using Yak.Gpio;
using Yak.Messaging;

namespace Yak.Processing
{
    public class ProcessingServer
    {   
        public void Start(bool useEmulator)
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
            var queue = new Yak.Messaging.Queue();
            queue.SetupReceiver(sherpa);
        }
    }
}
