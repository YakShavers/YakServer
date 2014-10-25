using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yak.Sherpa.Lib
{
    public interface IYakGPIO
    {
        void SetPin(Pin pin, bool high);
    }
}
