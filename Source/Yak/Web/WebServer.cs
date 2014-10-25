using System;
using System.Globalization;

namespace Yak.Web
{
    public class WebServer : IDisposable
    {
        private IDisposable app;
        public string Url { get; set; }

        private WebServer(IDisposable app, string url)
        {
            this.app = app;
            this.Url = url;
        }

        public static WebServer Start(int port)
        {
            var url = "http://+:" + port.ToString(CultureInfo.InvariantCulture);
            var app = Microsoft.Owin.Hosting.WebApp.Start<Startup>(url);
            var webServer = new WebServer(app, url);
            return webServer;
        }

        public void Dispose()
        {
            this.app.Dispose();
        }
    }
}