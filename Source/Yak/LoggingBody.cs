using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak
{
    public class LoggingBody: IBody
    {
        private readonly string prefix;

        public LoggingBody(string prefix = "")
        {
            this.prefix = prefix;
        }

        public void Eyes(Nerves.LedColor eyeColor)
        {
            Console.WriteLine(prefix + "Eyes:" + eyeColor.ToString());
        }

        public void Initialize()
        {
            Console.WriteLine(prefix + "Initialize");
        }

        public void Rifle(Nerves.LedColor rifleColor)
        {
            Console.WriteLine(prefix + "Rifle:" + rifleColor.ToString());
        }

        public void TearDown()
        {
            Console.WriteLine(prefix + "TearDown");

        }

        public void Wait(int waitTime)
        {
            Console.WriteLine(prefix + "Wait:" + waitTime.ToString());

        }
    }
}
