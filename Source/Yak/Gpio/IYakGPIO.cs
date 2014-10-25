namespace Yak.Gpio
{
    public interface IYakGPIO
    {
        void SetPin(Pin pin, bool high);

        void Initialize();

        void TearDown();
    }
}