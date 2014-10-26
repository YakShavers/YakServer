using Yak;

namespace Yak.Nerves
{
    public class NullYakNerves : IYakNerves
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