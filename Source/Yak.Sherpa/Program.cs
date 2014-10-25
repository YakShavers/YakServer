using System;
using System.Diagnostics;
using Yak.Processing;
namespace Yak.Sherpa
{
    internal class Program
    {
        enum Mode
        {
            WebServer,
            CommandProcesor
        }

        private static void Main(string[] args)
        {
            var mode = Mode.CommandProcesor;
            //var mode = Mode.WebServer;

            switch (mode)
            {
                case Mode.WebServer:
                    {
                        var server = new Yak.Web.WebServer();
                        server.Start(9264, url =>
                        {
                            Console.WriteLine("Running on {0}", url);
                            Console.WriteLine("Press enter to exit");

                            var startUrl = url.Replace("/+:", "/localhost:");
                            // + "/Eyes/Green";

                            Process.Start(new ProcessStartInfo
                            {
                                FileName = startUrl
                            });

                            Console.ReadLine();
                        });
                    }
                    break;
                case Mode.CommandProcesor:
                    {
                        var commandProcessor = new ProcessingServer();
                        commandProcessor.Start(false);

                        Console.WriteLine("Command Processor Running");
                        Console.WriteLine("Press enter to exit");
                        Console.ReadLine();
                    }
                    break;
            }
        }
    }
}