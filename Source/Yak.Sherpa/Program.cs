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
            bool useEmulator = false;
            using (var webServer = Yak.Web.WebServer.Start(9264))
            using (var processingServer = Yak.Processing.ProcessingServer.Start(useEmulator))
            {
                Console.WriteLine("Running on {0}", webServer.Url);
                Console.WriteLine("Press enter to exit");

                var startUrl = webServer.Url.Replace("/+:", "/localhost:");
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = startUrl
                });

                Console.ReadLine();
            }

        }
    }
}