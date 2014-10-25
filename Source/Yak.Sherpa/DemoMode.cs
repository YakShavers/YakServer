using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.Sherpa
{
    class DemoMode
    {
        public void Run()
        {
            var log = new Yak.Common.ConsoleLog();
            var gpio = new Yak.Gpio.YakLoggingGPIO(log);
            var sherpa = new Yak.Emulator.Yaksimile(gpio);
            sherpa.Initialize();

            var allColors = new[] {
                Yak.Gpio.LedColor.Green, 
                Yak.Gpio.LedColor.Amber, 
                Yak.Gpio.LedColor.Red, 
                //Yak.Gpio.LedColor.Off, 
                Yak.Gpio.LedColor.Blue 
            };

            var rnd = new Random();
            while (true)
            {
                var colorIndex = rnd.Next(0, allColors.Length);
                Yak.Gpio.LedColor color = allColors[colorIndex];

                // blink and shoot
                sherpa.Eyes(color);
                sherpa.Rifle(color);
                sherpa.Wait(250);
                sherpa.Eyes(Yak.Gpio.LedColor.Off);
                sherpa.Wait(250);
                sherpa.Eyes(color);
                sherpa.Wait(250);
                sherpa.Eyes(Yak.Gpio.LedColor.Off);
                sherpa.Wait(250);
                sherpa.Eyes(color);
                sherpa.Rifle(color);
                sherpa.Wait(250);
                sherpa.Eyes(Yak.Gpio.LedColor.Off);
                sherpa.Rifle(Yak.Gpio.LedColor.Off);

                sherpa.Wait(500);



            }
        }
    }
}
