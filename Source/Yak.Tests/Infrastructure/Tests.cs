using Yak;
using Yak.Nerves;

namespace Yak.Infrastructure
{
    public delegate void LoggedSherpaTest(Body sherpa, LogResult logResult);

    public static class Tests
    {
        public static void Run(LoggedSherpaTest test)
        {
            var log = new DebugLog();
            var yak = new LoggingYakNerves(log);
            LogResult logResult = () => log.CurrentContent;
            var sherpa = new Body(yak);
            test(sherpa, logResult);
        }
    }
}