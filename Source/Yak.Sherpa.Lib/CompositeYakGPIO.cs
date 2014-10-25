using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yak.Sherpa.Lib
{
    class CompositeYakGPIO: IYakGPIO
    {
        List<IYakGPIO> gpios;

        public CompositeYakGPIO(ICollection<IYakGPIO> gpios)
        {
            this.gpios = new List<IYakGPIO>(gpios);

        }

        public void SetPin(Pin pin, bool high)
        {
            foreach (var gpio in this.gpios)
            {
                gpio.SetPin(pin, high);
            }
        }

        public void Initialize()
        {
            foreach (var gpio in this.gpios)
            {
                gpio.Initialize();
            }
        }

        public void TearDown()
        {
            // tear down in inverse order from intialization
            var reversed = new List<IYakGPIO>(this.gpios);
            reversed.Reverse();
            foreach (var gpio in reversed)
            {
                gpio.TearDown();
            }
        }
    }
}
