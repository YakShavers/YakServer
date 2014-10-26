using Yak.Common;

namespace Yak.Nerves
{
    public class LoggingYakNerves : IYakNerves
    {
        private readonly ILog log;

        public LoggingYakNerves(ILog log)
        {
            this.log = log;
        }

        public void SetPin(Pin pin, bool high)
        {
            var message = string.Format("SET PIN {0} TO {1}", pin, high ? "ON" : "OFF");
            this.log.Info(message);
        }

        public void Initialize()
        {
        }

        public void TearDown()
        {
        }
    }
}