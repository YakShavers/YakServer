using System.Windows.Forms;
using Yak;
using Yak.Gpio;

namespace Yak.Emulator
{
    public class Yaksimile : Sherpa
    {
        private YakscimileForm form;

        public Yaksimile(IYakGPIO yak)
            : base(yak)
        {
        }

        public void Initialize()
        {
            base.Initialize();

            // show the yak window!
            this.form = new YakscimileForm();
            this.form.Show();
            this.form.BringToFront();

            this.Eyes(LedColor.Off);
            this.Rifle(LedColor.Off);
            this.form.Refresh();
        }

        public void TearDown()
        {
            // hide the yak window
            this.form.Hide();
            this.form = null;

            base.TearDown();
        }

        public void Eyes(LedColor eyeColor)
        {
            this.form.DrawLeftEye(eyeColor);
            this.form.DrawRightEye(eyeColor);
            this.Pump();
        }

        public void Rifle(LedColor rifleColor)
        {
            this.form.DrawRifle(rifleColor);
            this.Pump();
        }

        private void Pump()
        {
            this.form.Refresh();
            Application.DoEvents();
        }

        public void Wait(int waitTime)
        {
            base.Wait(waitTime);
            this.Pump();
        }
    }
}