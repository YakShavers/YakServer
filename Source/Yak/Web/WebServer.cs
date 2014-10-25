using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak.Web
{
    public class WebServer
    {
        public void Start(int port, Action<string> waitMethod)
        {
            var url = "http://+:" + port.ToString(CultureInfo.InvariantCulture);

            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url))
            {
                waitMethod(url);
            }
        }
    }
}