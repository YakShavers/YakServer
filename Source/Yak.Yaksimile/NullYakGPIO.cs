using Yak.Sherpa.Lib;

namespace Yak.Yaksimile
{
    public class NullYakGPIO : IYakGPIO
    {
        public void SetPin(Pin pin, bool high)
        {
        }

        public void Initialize()
        {
        }

        public void TearDown()
        {
        }
    }
}