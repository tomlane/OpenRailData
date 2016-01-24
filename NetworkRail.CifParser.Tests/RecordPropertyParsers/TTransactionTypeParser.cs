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

                Assert.Throws<ArgumentNullException>(() => parser.ParseTransactionType(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseTransactionType(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseTransactionType(" \t"));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new TransactionTypeParser();

                var result = parser.ParseTransactionType("N");
                Assert.AreEqual(TransactionType.New, result);

                result = parser.ParseTransactionType("R");
                Assert.AreEqual(TransactionType.Revise, result);

                result = parser.ParseTransactionType("D");
                Assert.AreEqual(TransactionType.Delete, result);
            }

            [Test]
            public void returns_unknown_when_argument_is_unknown()
            {
                var parser = new TransactionTypeParser();

                Assert.Throws<ArgumentException>(() => parser.ParseTransactionType("Z"));
            }
        }
    }
}