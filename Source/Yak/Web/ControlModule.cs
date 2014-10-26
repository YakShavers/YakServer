using Nancy;
using System;
using Yak.Nerves;
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
                var body = new QueuedBody();
                var brain = new Brain(body);
                for (var i = 0; i < 50; i++)
                {
                    brain.Succeeded();
                    brain.Failed();
                    brain.Quiet();
                }

                return "Crazy Eyes!!!";
            };

            foreach (var color in allColors)
            {
                var url = "/Eyes/" + color.ToString();
                var message = "Turn eyes " + color.ToString();
                Get[url] = _ =>
                    {
                        var body = new QueuedBody();
                        body.Eyes(color);
                        return message;
                    };
            }
        }
    }
}