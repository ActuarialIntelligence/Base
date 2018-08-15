using AI.ThreadManagement.Interfaces;
using NUnit.Framework;
using System;
using Moq;
using AI.ThreadManagement.Looping;

namespace Threading.Tests
{
    [TestFixture]
    [Category("ThreadLooping")]
    public class ThreadBasedLoopingTests
    {
        Looping looping;
        [SetUp]
        public void BeforeEachTest()
        {
            var decider = new Mock<IDecide>();
            decider.Setup(m => m.TaskCapacity).Returns(4);
            looping = new Looping(decider.Object);
        }
        //[TestCaseSource(typeof(ThreadLoopingTestData), "BreaksTestData")]
        [Test]
        public void AssertBreaksWork()
        {
            int remainder;
            decimal increment = 0.2m;
            decimal initialValue = 1m;
            int i = 0;//Loop counter.
            int tasks = 5;
            var noOfIncrements = (int)(((6.2m - 1m) / 0.2m));
            var breaks = Math.DivRem(noOfIncrements, tasks, out remainder);
            Assert.AreEqual(breaks, 5);
            Assert.AreEqual(remainder, 1);

            Assert.AreEqual(initialValue + (i * breaks), 1m);
            Assert.AreEqual(initialValue + ((i + 1) * breaks * increment), 2m);

            Assert.AreEqual(initialValue + ((tasks - 1) * breaks * increment), 5m);
            Assert.AreEqual(initialValue + ((tasks * breaks * increment) + (remainder * increment)), 6.2m);
        }
    }
}
