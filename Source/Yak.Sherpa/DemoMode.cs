using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.Sherpa
{
    class DemoMode
    {
        public IBody DemoBody()
        {
            var log = new Yak.Common.ConsoleLog();
            var nerves = new Yak.Nerves.LoggingYakNerves(log);
            var yaksimile = new Yak.Emulator.Yaksimile(nerves);
            var logger = new LoggingBody("");
            var composite = new CompositeBody(logger, yaksimile);
            return composite;
        }

        public void Run()
        {
            var body = DemoBody();
            this.Run(body);
        }

        public void Run(IBody body)
        {           
            var brain = new Brain(body);
            brain.Succeeded();
            brain.Failed();
            brain.Quiet();
            brain.Succeeded();
            brain.Failed();
            brain.Quiet();
        }
    }
}
