using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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
            public void returns_expected_result_from_argument()
            {
                var parser = new TransactionTypeParser();

                var result = parser.ParseProperty("N");
                Assert.AreEqual(TransactionType.New, result);

                result = parser.ParseProperty("R");
                Assert.AreEqual(TransactionType.Revise, result);

                result = parser.ParseProperty("D");
                Assert.AreEqual(TransactionType.Delete, result);
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