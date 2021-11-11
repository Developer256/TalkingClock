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

            result = Virtusa.TellTime("12:29");
            Assert.AreEqual(result, "Twenty-nine past twelve");

            result = Virtusa.TellTime("12:31");
            Assert.AreEqual(result, "Twenty-nine to one");

            result = Virtusa.TellTime("2:00");
            Assert.AreEqual(result, "Two o'clock");

            result = Virtusa.TellTime("2:10");
            Assert.AreEqual(result, "Ten past two");

            result = Virtusa.TellTime("14:30");
            Assert.AreEqual(result, "Half past two");

            result = Virtusa.TellTime("22:47");
            Assert.AreEqual(result, "Thirteen to eleven");

            result = Virtusa.TellTime("23:45");
            Assert.AreEqual(result, "Quarter to midnight");

            result = Virtusa.TellTime("23:59");
            Assert.AreEqual(result, "One to midnight");

            result = Virtusa.TellTime("00:01");
            Assert.AreEqual(result, "One past midnight");
        }
    }
}