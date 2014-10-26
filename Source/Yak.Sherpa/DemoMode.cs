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
            var nerves = new Yak.Nerves.LoggingYakNerves(log);
            var body = new Yak.Emulator.Yaksimile(nerves);
            this.Run(body);
        }

        public void Run(IBody body)
        {           
            body.Initialize();

            var brain = new Brain(body);
            brain.Succeeded();
            brain.Failed();
            brain.Quiet();
            brain.Succeeded();
            brain.Failed();
            brain.Quiet();

            //var allColors = new[] {
            //    Yak.Nerves.LedColor.Green, 
            //    Yak.Nerves.LedColor.Amber, 
            //    Yak.Nerves.LedColor.Red, 
            //    Yak.Nerves.LedColor.Blue 
            //};

            //var rnd = new Random();
            //while (true)
            //{
            //    var colorIndex = rnd.Next(0, allColors.Length);
            //    Yak.Nerves.LedColor color = allColors[colorIndex];

            //    // blink and shoot
            //    body.Eyes(color);
            //    body.Rifle(color);
            //    body.Wait(250);
            //    body.Eyes(Yak.Nerves.LedColor.Off);
            //    body.Wait(250);
            //    body.Eyes(color);
            //    body.Wait(250);
            //    body.Eyes(Yak.Nerves.LedColor.Off);
            //    body.Wait(250);
            //    body.Eyes(color);
            //    body.Rifle(color);
            //    body.Wait(250);
            //    body.Eyes(Yak.Nerves.LedColor.Off);
            //    body.Rifle(Yak.Nerves.LedColor.Off);
            //    body.Wait(500);
            //}
        }
    }
}
