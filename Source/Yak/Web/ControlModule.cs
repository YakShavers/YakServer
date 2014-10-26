using Nancy;
using System;
using Yak.Gpio;
using Yak.Messaging;

namespace Yak.Web
{
    public class ControlModule : NancyModule
    {
        public ControlModule()
        {
            var allColors = new[] {
                LedColor.Green,
                LedColor.Amber,
                LedColor.Red,
                LedColor.Off,
                LedColor.Blue
            };

            Get["/"] = _ =>
            {
                return "Welcome to the YakServer";
            };

            Get["/crazyeyes"] = _ =>
            {
                var queue = new Messaging.Queue();
                var rnd = new Random();
                for (var i = 0; i < 250; i++)
                {
                    var colorIndex = rnd.Next(0, allColors.Length);
                    LedColor color = allColors[colorIndex];
                    queue.Send(new SetEyeColor { EyeColor = color });
                    queue.Send(new Wait { Time = 250 });
                }

                return "Crazy Eyes!!!";
            };

            foreach (var color in allColors)
            {
                var url = "/Eyes/" + color.ToString();
                var message = "Turn eyes " + color.ToString();
                Get[url] = _ =>
                    {
                        new Messaging.Queue().Send(new SetEyeColor { EyeColor = color });
                        return message;
                    };
            }
        }
    }
}