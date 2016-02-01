using NUnit.Framework;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser
{
    [TestFixture]
    public class TCifScheduleParser
    {
        [Test]
        public void record_length_check()
        {
            //should throw when record length is not 80
            Assert.Inconclusive();
        }

        [Test]
        public void unknown_record_type()
        {
            // should throw when record type is not known and no parser is available to handle it
            Assert.Inconclusive();
        }
    }
}