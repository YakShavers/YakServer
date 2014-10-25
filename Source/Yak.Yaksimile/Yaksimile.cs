using Yak.Sherpa.Lib;

namespace Yak.Yaksimile
{
    public class Yaksimile : Yak.Sherpa.Lib.Sherpa
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
            this.form.Refresh();

            this.Eyes(LedColor.Off);
            this.Rifle(LedColor.Off);
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
        }

        public void Rifle(LedColor rifleColor)
        {
            this.form.DrawRifle(rifleColor);
        }

        public void Wait(int waitTime)
        {
            base.Wait(waitTime);
        }
    }
}