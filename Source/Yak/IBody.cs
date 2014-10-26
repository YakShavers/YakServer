using System;
namespace Yak
{
    public interface IBody
    {
        void Eyes(Yak.Nerves.LedColor eyeColor);
        void Initialize();
        void Rifle(Yak.Nerves.LedColor rifleColor);
        void TearDown();
        void Wait(int waitTime);
    }
}
