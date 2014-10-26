using System;
using System.Collections.Generic;
using Yak.Nerves;

namespace Yak
{
    public class Body : Yak.IBody
    {
        protected readonly IYakNerves nerves;

        public Body(IYakNerves yak)
        {
            // save the yak instance.
            this.nerves = yak;
        }

        public virtual void Eyes(LedColor eyeColor)
        {
            SetLedColor(eyeColor, Pin.LeftEyeRed, Pin.LeftEyeGreen, Pin.LeftEyeBlue);
            SetLedColor(eyeColor, Pin.RightEyeRed, Pin.RightEyeGreen, Pin.RightEyeBlue);
        }

        public virtual void Rifle(LedColor rifleColor)
        {
            this.SetLedColor(rifleColor, Pin.RifleRed, Pin.RifleGreen, Pin.RifleBlue);
        }

        private void SetLedColor(LedColor color, Pin redPin, Pin greenPin, Pin bluePin)
        {
            var colorMap = new Dictionary<LedColor, string>
            {
                { LedColor.Red , "100" },
                { LedColor.Amber , "110" },
                { LedColor.Green , "010" },
                { LedColor.Blue , "001" },
                { LedColor.Off , "000" },
            };

            var colorString = colorMap[color];

            Func<int, bool> getPinValue = pin =>
            {
                var ch = colorString[pin];
                return ch == '0' ? false : true;
            };

            this.nerves.SetPin(redPin, getPinValue(0));
            this.nerves.SetPin(greenPin, getPinValue(1));
            this.nerves.SetPin(bluePin, getPinValue(2));
        }

        public virtual void Wait(int waitTime)
        {
            System.Threading.Thread.Sleep(waitTime);
        }

        public virtual void Initialize()
        {
            this.nerves.Initialize();
        }

        public virtual void TearDown()
        {
            this.nerves.TearDown();
        }
    }
}