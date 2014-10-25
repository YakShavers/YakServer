using Yak.Common;

namespace Yak.Gpio
{
    public class YakLoggingGPIO : IYakGPIO
    {
        private readonly ILog log;

        public YakLoggingGPIO(ILog log)
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