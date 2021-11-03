using NUnit.Framework;
using TalkingClock;

namespace ClockTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ClockTest()
        {
            string result = Virtusa.TellTime("ABC15.15def#~");
            Assert.AreEqual(result, "Quarter past three");

            result = Virtusa.TellTime("ABC15:15fed#~");
            Assert.AreEqual(result, "Quarter past three");

            result = Virtusa.TellTime("0:00");
            Assert.AreEqual(result, "Midnight");

            result = Virtusa.TellTime("2:00");
            Assert.AreEqual(result, "Two o'clock");

            result = Virtusa.TellTime("2:10");
            Assert.AreEqual(result, "Ten past two");

            result = Virtusa.TellTime("23:59");
            Assert.AreEqual(result, "One to midnight");
        }
    }
}