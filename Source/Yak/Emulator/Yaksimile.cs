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

        public override void Initialize()
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

        public override void TearDown()
        {
            // hide the yak window
            this.form.Hide();
            this.form = null;

            base.TearDown();
        }

        public override void Eyes(LedColor eyeColor)
        {
            this.form.DrawLeftEye(eyeColor);
            this.form.DrawRightEye(eyeColor);
            this.Pump();
        }

        public override void Rifle(LedColor rifleColor)
        {
            this.form.DrawRifle(rifleColor);
            this.Pump();
        }

        private void Pump()
        {
            this.form.Invoke(new Refresher(PumpInvoked));
        }

        private void PumpInvoked()
        {
#warning SC this doesn't throw but the screen fails to refresh in server mode
            this.form.Refresh();
            Application.DoEvents();
        }

        private delegate void Refresher();

        public override void Wait(int waitTime)
        {
            base.Wait(waitTime);
            this.Pump();
        }
    }
}