﻿using System;
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
                sherpa.Eyes(LedColor.Red);
                Assert.AreEqual(TestResults.EyesRed, log(), "red eyes");

                sherpa.Eyes(LedColor.Amber);
                Assert.AreEqual(TestResults.EyesAmber, log(), "amber eyes");

                sherpa.Eyes(LedColor.Green);
                Assert.AreEqual(TestResults.EyesGreen, log(), "green eyes");

                sherpa.Eyes(LedColor.Off);
                Assert.AreEqual(TestResults.EyesOff, log(), "blank eyes");

                sherpa.Rifle(LedColor.Red);
                Assert.AreEqual(TestResults.RifleRed, log(), "red rifle");

                sherpa.Rifle(LedColor.Off);
                Assert.AreEqual(TestResults.RifleOff, log(), "Rifle off");
            });
        }
    }
}
