using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser
{
    [TestFixture]
    public class TFileScheduleReader
    {
        [TestFixture]
        class ReadSchedule
        {
            [Test]
            public void throws_when_argument_is_null_or_whitespace()
            {
                var reader = new FileScheduleReader();

                Assert.Throws<ArgumentNullException>(() => reader.ReadSchedule(null));
                Assert.Throws<ArgumentNullException>(() => reader.ReadSchedule(string.Empty));
                Assert.Throws<ArgumentNullException>(() => reader.ReadSchedule(" \t"));
            }
        }
    }
}