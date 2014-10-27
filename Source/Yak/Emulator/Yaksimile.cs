using System.Windows.Forms;
using Yak;
using Yak.Nerves;

namespace Yak.Emulator
{
    public class Yaksimile : Body
    {
        private YakscimileForm form;

        public Yaksimile(IYakNerves yak)
            : base(yak)
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            // show the yak window!
            this.form = new YakscimileForm();
            this.form.Text = "I, Yakbot: The Yaksimile";
            this.form.Show();
            this.form.BringToFront();

            this.Eyes(LedColor.Red);
            this.Rifle(LedColor.Blue);
            this.form.Refresh();
        }

        public override void TearDown()
        {
            // hide the yak window
            this.form.Close();
            this.form = null;

            base.TearDown();
        }

        public override void Eyes(LedColor eyeColor)
        {
            base.Eyes(eyeColor);
            this.form.DrawLeftEye(eyeColor);
            this.form.DrawRightEye(eyeColor);
            this.form.Pump();
        }

        public override void Rifle(LedColor rifleColor)
        {
            base.Rifle(rifleColor);
            this.form.DrawRifle(rifleColor);
            this.form.Pump();
        }

        public override void Wait(int waitTime)
        {
            base.Wait(waitTime);
            this.form.Pump();
        }
    }
}