namespace Yak.Nerves
{
    public interface IYakNerves
    {
        void SetPin(Pin pin, bool high);

        void Initialize();

        void TearDown();
    }
}