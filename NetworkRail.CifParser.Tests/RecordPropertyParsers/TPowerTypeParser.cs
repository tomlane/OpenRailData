using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TPowerTypeParser
    {
        [Test]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = new PowerTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Test]
        public void returns_expected_result_when_argument_is_valid()
        {
            var parser = new PowerTypeParser();

            var result = parser.ParseProperty("D");
            Assert.AreEqual(PowerType.D, result);

            result = parser.ParseProperty("DEM");
            Assert.AreEqual(PowerType.DEM, result);

            result = parser.ParseProperty("DMU");
            Assert.AreEqual(PowerType.DMU, result);

            result = parser.ParseProperty("E");
            Assert.AreEqual(PowerType.E, result);

            result = parser.ParseProperty("ED");
            Assert.AreEqual(PowerType.ED, result);

            result = parser.ParseProperty("EML");
            Assert.AreEqual(PowerType.EML, result);

            result = parser.ParseProperty("EMU");
            Assert.AreEqual(PowerType.EMU, result);

            result = parser.ParseProperty("EPU");
            Assert.AreEqual(PowerType.EPU, result);

            result = parser.ParseProperty("HST");
            Assert.AreEqual(PowerType.HST, result);

            result = parser.ParseProperty("LDS");
            Assert.AreEqual(PowerType.LDS, result);
        }

        [Test]
        public void throws_when_argument_is_unknown()
        {
            var parser = new PowerTypeParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}