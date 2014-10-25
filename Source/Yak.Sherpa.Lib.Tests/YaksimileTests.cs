using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Yak.Sherpa.Lib.Tests
{
    [TestClass]
    public class YaksimileTests
    {
        [TestMethod]
        public void Yaksimile_OpensAndCloses()
        {
            var yaksimile = new Yak.Yaksimile.Yaksimile();
            yaksimile.Initialize();
            Thread.Sleep(500);
            yaksimile.TearDown();
        }
    }
}
