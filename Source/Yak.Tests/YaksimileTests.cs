using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yak.Emulator;
using Yak.Nerves;
using Yak.Processing;

namespace Yak.Tests
{
    //[Ignore]
    [TestClass]
    public class YaksimileTests
    {
        [Ignore]
        [TestMethod]
        public void Yaksimile_WorksUsingServer()
        {
            var body = new QueuedBody();
        }

        [Ignore]
        [TestMethod]
        public void Yaksimile_OpensAndCloses()
        {
            var yaksimile = new Yaksimile(new NullYakNerves());
            RunTest(yaksimile);
        }

        private void RunTest(IBody body)
        {
            body.Initialize();

            var brain = new Brain(body);
            brain.Succeeded();
            brain.Failed();
            brain.Quiet();

            brain.Succeeded();
            brain.Failed();
            brain.Quiet();

            body.TearDown();

        }
    }
}