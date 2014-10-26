using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yak.Nerves;

namespace Yak
{
    public class Brain
    {
        private readonly IBody body;
        private const int blinkTime = 250;
        private const int blinkFinalTime = 1000;

        public Brain(IBody body)
        {
            this.body = body;
        }

        public void Failed()
        {
            body.Rifle(LedColor.Red);
            Blink(LedColor.Red);
            body.Rifle(LedColor.Off);
        }

        private void Blink(LedColor color)
        {
            body.Eyes(color);
            body.Wait(blinkTime);

            body.Eyes(LedColor.Off);
            body.Wait(blinkTime);

            body.Eyes(color);
            body.Wait(blinkTime);

            body.Eyes(LedColor.Off);
            body.Wait(blinkTime);

            body.Eyes(color);
            body.Wait(blinkFinalTime);

            body.Eyes(LedColor.Off);
            body.Wait(blinkTime);
        }

        public void Succeeded()
        {
            body.Rifle(LedColor.Off);
            Blink(LedColor.Green);
        }

        public void Quiet()
        {
            body.Eyes(LedColor.Off);
            body.Rifle(LedColor.Off);
        }

    }
}
