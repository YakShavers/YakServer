using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak
{
    class WaitEventArgs: EventArgs
    {
        public int Delay { get; set; }

        public WaitEventArgs(int delay)
        {
            this.Delay = delay;
        }
    }
}
