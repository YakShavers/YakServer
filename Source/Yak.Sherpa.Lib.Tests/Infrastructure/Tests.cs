using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yak.Common;

namespace Yak.Sherpa.Lib.Tests.Infrastructure
{
    public delegate void LoggedSherpaTest(Sherpa sherpa, LogResult logResult);

    public static class Tests
    {
        public static void Run(LoggedSherpaTest test)
        {
            var log = new DebugLog();
            var yak = new YakLoggingGPIO(log);
            LogResult logResult = () => log.CurrentContent;
            var sherpa = new Sherpa(yak);
            test(sherpa, logResult);
        }
    }
}
