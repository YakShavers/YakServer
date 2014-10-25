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

        public void Eyes(EyeColor eyeColor)
        {
            var colorMap = new Dictionary<EyeColor, string>
            {
                { EyeColor.Red , "100100" },
                { EyeColor.Amber , "110110" },
                { EyeColor.Green , "010010" },
                { EyeColor.Blue , "001001" },
                { EyeColor.Off , "000000" },
            };

            var colorString = colorMap[eyeColor];
           
            Func<Pin, bool> getPinValue = pin => {
                var index = (int)pin;
                var ch = colorString[index];
                return ch == '0' ? false : true;
            };

            var pinsToSet = new [] {
                Pin.LeftEyeRed,
                Pin.LeftEyeGreen,
                Pin.LeftEyeBlue,
                Pin.RightEyeRed,
                Pin.RightEyeGreen,
                Pin.RightEyeBlue,
            };

            foreach(var pinToSet in pinsToSet)
            {
                var pinValue = getPinValue(pinToSet);
                this.yak.SetPin(pinToSet, pinValue);
            }
        }

        public void Rifle(bool lightUpRifle)
        {
            this.yak.SetPin(Pin.Rifle, lightUpRifle);
        }
    }
}
