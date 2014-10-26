using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Gpio;

namespace Yak
{
    public class LedColorChangeEventArgs: EventArgs
    {
        public LedColor Color { get; private set; }

        public LedColorChangeEventArgs(LedColor color)
        {
            this.Color = color;
        }
    }
}
