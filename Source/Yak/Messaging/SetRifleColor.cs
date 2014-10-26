using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Nerves;

namespace Yak.Messaging
{
    [Serializable]
    public class SetRifleColor
    {
        public LedColor RifleColor { get; set; }
    }
}
