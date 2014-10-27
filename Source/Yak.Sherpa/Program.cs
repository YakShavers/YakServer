using System;
using System.Diagnostics;
using System.Threading;

namespace Yak.Sherpa
{
    internal class Program
    {
        private enum Mode
        {
            WebServer,
            CommandProcesor
        }

        private static void Main(string[] args)
        {
            //var quitWaitHandle = new ManualResetEvent(false);

            //// start the web server
            //var webServerThread = new Thread(StartWebServerThread);
            //webServerThread.Start(quitWaitHandle);

            //// start the command processor
            //var commandProcessorThread = new Thread(StartCommandProcessorThread);
            //commandProcessorThread.Start(quitWaitHandle);

            ////  dump some messages
            //var body = new CompositeBody(new LoggingBody("Queueing "), new QueuedBody());
            //var demo = new DemoMode();
            ////demo.Run(body);

            //// wait for the 'quit' command.
            //Console.WriteLine("Press enter to exit");
            //Console.ReadLine();
            //quitWaitHandle.Set();
            //Console.WriteLine("Quitting. Please be patient.");

            var demo = new DemoMode();
            var body = demo.DemoBody();
            body.Initialize();
            while (true)
            {
                demo.Run(body);
            }
        }


        private static void StartWebServerThread(object quitWaitHandleObject)
        {
            ManualResetEvent quitWaitHandle = (ManualResetEvent)quitWaitHandleObject;

            bool useEmulator = false;
            using (var webServer = Yak.Web.WebServer.Start(9264))
            {
                Console.WriteLine("Running web server on {0}", webServer.Url);

                var startUrl = webServer.Url.Replace("/+:", "/localhost:");

                //Process.Start(new ProcessStartInfo
                //{
                //    FileName = startUrl
                //});

                quitWaitHandle.WaitOne();

                Console.WriteLine("Web Server Received Quit Signal");
            }
        }

        private static void StartCommandProcessorThread(object quitWaitHandleObject)
        {
            ManualResetEvent quitWaitHandle = (ManualResetEvent)quitWaitHandleObject;

            bool useEmulator = true;
            using (var processingServer = Yak.Processing.ProcessingServer.Start(useEmulator))
            {
                Console.WriteLine("Running processing server");
                quitWaitHandle.WaitOne();
                Console.WriteLine("Command Processor Received Quit Signal");

            }
        }
    }
}