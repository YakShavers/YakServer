using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Yak.Sherpa.Lib;

namespace Yak.Yaksimile
{
    public class Yaksimile: IYakGPIO
    {
        private YakscimileForm form;

        public void SetPin(Pin pin, bool high)
        {
            
        }


        public void Initialize()
        {
            // show the yak window!
            this.form = new YakscimileForm();
            this.form.Show();
        }

        public void TearDown()
        {
            // hide the yak window
            this.form.Hide();
            this.form = null;
        }
    }

    public class YakscimileForm : System.Windows.Forms.Form
    {
        public YakscimileForm()
        {
            var scale = 0.25;

            var backgroundImage = Resources.FormResources.YaksimileBackground;

            var scaleWidth = (int)(scale * backgroundImage.Width);
            var scaleHeight = (int)(scale * backgroundImage.Height);

            var scaledImage = new Bitmap(scaleWidth, scaleHeight); 
            var graph = Graphics.FromImage(scaledImage);

            graph.DrawImage(backgroundImage, 0,0,scaleWidth, scaleHeight);

            this.BackgroundImage = scaledImage;
            this.Width = scaleWidth;
            this.Height = scaleHeight;
        }
    }
}
