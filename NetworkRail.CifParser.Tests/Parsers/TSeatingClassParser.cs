using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseSeatingClass(null));
            }

            [Test]
            public void returns_expected_result_when_argument_string_is_empty()
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseSeatingClass(string.Empty);

                Assert.AreEqual(SeatingClass.FirstAndStandardClass, result);
            }

            [Test]
            public void returns_expected_result_when_argument_is_valid()
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseSeatingClass("S");

                Assert.AreEqual(SeatingClass.StandardClassOnly, result);

                result = parser.ParseSeatingClass("B");

                Assert.AreEqual(SeatingClass.FirstAndStandardClass, result);
            }
        }
    }
}