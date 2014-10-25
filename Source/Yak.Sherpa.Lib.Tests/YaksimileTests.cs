using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yak.Yaksimile;

namespace Yak.Sherpa.Lib.Tests
{
    [TestClass]
    public class YaksimileTests
    {
        [TestMethod]
        public void Yaksimile_OpensAndCloses()
        {
            var waitTime = 500;
            var yaksimile = new Yak.Yaksimile.Yaksimile(new NullYakGPIO());
            yaksimile.Initialize();

            yaksimile.Wait(waitTime);
            yaksimile.Eyes(LedColor.Red);
            yaksimile.Rifle(LedColor.Green);
            yaksimile.Wait(waitTime);
            yaksimile.Eyes(LedColor.Green);
            yaksimile.Eyes(LedColor.Blue);
            yaksimile.Wait(waitTime);
            yaksimile.Eyes(LedColor.Blue);
            yaksimile.Eyes(LedColor.Amber);
            yaksimile.Wait(waitTime);
            yaksimile.Eyes(LedColor.Off);
            yaksimile.Rifle(LedColor.Off);
            yaksimile.Wait(waitTime);

            yaksimile.TearDown();
        }
    }
}