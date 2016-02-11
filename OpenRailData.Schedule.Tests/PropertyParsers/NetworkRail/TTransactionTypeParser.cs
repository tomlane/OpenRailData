using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
{
    [TestFixture]
    public class TTransactionTypeParser
    {
        [TestFixture]
        class ParseTransactionType
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new TransactionTypeParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
            }

            [Test]
            public void returns_correct_values_from_cif_records()
            {
                var parser = new TransactionTypeParser();

                var result = parser.ParseProperty("N");
                Assert.AreEqual(TransactionType.N, result);

                result = parser.ParseProperty("R");
                Assert.AreEqual(TransactionType.R, result);

                result = parser.ParseProperty("D");
                Assert.AreEqual(TransactionType.D, result);
            }

            [Test]
            public void returns_correct_values_from_json_records()
            {
                var parser = new TransactionTypeParser();

                var result = parser.ParseProperty("create");
                Assert.AreEqual(TransactionType.N, result);

                result = parser.ParseProperty("update");
                Assert.AreEqual(TransactionType.R, result);

                result = parser.ParseProperty("delete");
                Assert.AreEqual(TransactionType.D, result);
            }

            [Test]
            public void returns_unknown_when_argument_is_unknown()
            {
                var parser = new TransactionTypeParser();

                Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
            }
        }
    }
}