using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yak.Sherpa.Lib.Tests.Infrastructure;
using Yak.Sherpa.Lib.Tests.Resources;

namespace Yak.Sherpa.Lib.Tests
{
    [TestClass]
    public class SherpaTests
    {
        [TestMethod]
        public void Sherpa_CanBlinkEyes()
        {
            Infrastructure.Tests.Run( (sherpa, log) =>
            {
                sherpa.Eyes(EyeColor.Red);
                Assert.AreEqual(TestResults.EyesRed, log());

                sherpa.Eyes(EyeColor.Amber);
                Assert.AreEqual(TestResults.EyesAmber, log());

                sherpa.Eyes(EyeColor.Green);
                Assert.AreEqual(TestResults.EyesGreen, log());

                sherpa.Eyes(EyeColor.Blue);
                Assert.AreEqual(TestResults.EyesBlue, log());

                sherpa.Rifle(true);
                Assert.AreEqual(TestResults.RifleOn, log());

                sherpa.Rifle(false);
                Assert.AreEqual(TestResults.RifleOff, log());
            });
        }
    }
}
