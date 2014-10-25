using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yak.Sherpa.Lib;

namespace Yak.Yaksimile
{
    public class Yaksimile: IYakGPIO
    {
        public void SetPin(Pin pin, bool high)
        {
            
        }


        public void Initialize()
        {
            // show the yak window!
        }

        public void TearDown()
        {
            // hide the yak window
        }
    }
}
