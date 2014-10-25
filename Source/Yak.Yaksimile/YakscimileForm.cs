using System.Collections.Generic;
using System.Drawing;
using Yak.Sherpa.Lib;

namespace Yak.Yaksimile
{
    public class YakscimileForm : System.Windows.Forms.Form
    {
        private Point leftEye = new Point(167, 82);
        private Point rightEye = new Point(190, 75);
        private Point rifleStart = new Point(50, 180);
        private Point rifleEnd = new Point(70, 220);

        private float scaleFactor = 0.25f;

        public YakscimileForm()
        {
            //this.Scale(new SizeF(scaleFactor,scaleFactor));

            var scale = scaleFactor;

            var backgroundImage = Resources.FormResources.YaksimileBackground;

            var scaleWidth = (int)(scale * backgroundImage.Width);
            var scaleHeight = (int)(scale * backgroundImage.Height);

            var scaledImage = new Bitmap(scaleWidth, scaleHeight);
            var graph = Graphics.FromImage(scaledImage);

            graph.DrawImage(backgroundImage, 0, 0, scaleWidth, scaleHeight);

            this.BackgroundImage = scaledImage;
            this.Width = scaleWidth + 50;
            this.Height = scaleHeight + 50;
        }

        internal void DrawLeftEye(Sherpa.Lib.LedColor eyeColor)
        {
            this.DrawEye(eyeColor, this.leftEye);
            this.Refresh();
        }

        internal void DrawRightEye(Sherpa.Lib.LedColor eyeColor)
        {
            this.DrawEye(eyeColor, this.rightEye);
            this.Refresh();
        }

        private readonly Dictionary<LedColor, Brush> brushMap = new Dictionary<LedColor, Brush>
        {
            { LedColor.Green, Brushes.Green },
            { LedColor.Amber, Brushes.Yellow },
            { LedColor.Red, Brushes.Red },
            { LedColor.Blue, Brushes.Blue },
            { LedColor.Off, Brushes.Black },
        };

        private void DrawEye(Sherpa.Lib.LedColor eyeColor, Point point)
        {
            var brush = brushMap[eyeColor];
            var eyeSize = 10;
            var g = Graphics.FromImage(this.BackgroundImage);
            g.FillEllipse(
                brush,
                point.X - eyeSize,
                point.Y - eyeSize,
                eyeSize * 2,
                eyeSize * 2);
        }

        internal void DrawRifle(Sherpa.Lib.LedColor rifleColor)
        {
            var brush = brushMap[rifleColor];
            var g = Graphics.FromImage(this.BackgroundImage);
            using (var pen = new Pen(brush, 8))
            {
                g.DrawLine(pen, this.rifleStart, this.rifleEnd);
            }
        }
    }
}