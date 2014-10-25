using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yak.Sherpa.Lib
{
    public class Sherpa
    {
        private IYakGPIO yak;

        public Sherpa(IYakGPIO yak)
        {
            // save the yak instance.
            this.yak = yak;
        }

        public void Eyes(LedColor eyeColor)
        {
            SetLedColor(eyeColor, Pin.LeftEyeRed, Pin.LeftEyeGreen, Pin.LeftEyeBlue);
            SetLedColor(eyeColor, Pin.RightEyeRed, Pin.RightEyeGreen, Pin.RightEyeBlue); 
        }

        public void Rifle(LedColor rifleColor)
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

            this.yak.SetPin(redPin, getPinValue(0));
            this.yak.SetPin(greenPin, getPinValue(1));
            this.yak.SetPin(bluePin, getPinValue(2));
        }
    }
}
