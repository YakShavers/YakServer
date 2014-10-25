using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Gpio;

namespace Yak.Messaging
{
    [Serializable]
    public class SetEyeColor
    {
        public LedColor EyeColor { get; set; }
    }
}
