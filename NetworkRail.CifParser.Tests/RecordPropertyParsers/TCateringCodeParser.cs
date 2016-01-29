using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TCateringCodeParser
    {
        [Test]
        public void throws_if_argument_string_is_null()
        {
            var parser = new CateringCodeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        public void returns_expected_result()
        {
            var parser = new CateringCodeParser();

            string activities = "CFHMPRT";

            var result = parser.ParseProperty(activities);

            Assert.IsTrue(result.HasFlag(CateringCode.C));
            Assert.IsTrue(result.HasFlag(CateringCode.F));
            Assert.IsTrue(result.HasFlag(CateringCode.H));
            Assert.IsTrue(result.HasFlag(CateringCode.M));
            Assert.IsTrue(result.HasFlag(CateringCode.P));
            Assert.IsTrue(result.HasFlag(CateringCode.R));
            Assert.IsTrue(result.HasFlag(CateringCode.T));
        }
    }
}