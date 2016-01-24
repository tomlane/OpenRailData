using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TSeatingClassParser
    {
        [TestFixture]
        class ParseSeatingClass
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var parser = new SeatingClassParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result_when_argument_string_is_empty()
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseProperty(string.Empty);

                Assert.AreEqual(SeatingClass.B, result);
            }

            [Test]
            public void returns_expected_result_when_argument_is_valid()
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseProperty("S");

                Assert.AreEqual(SeatingClass.S, result);

                result = parser.ParseProperty("B");

                Assert.AreEqual(SeatingClass.B, result);
            }
        }
    }
}