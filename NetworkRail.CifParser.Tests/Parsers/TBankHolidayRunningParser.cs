using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TBankHolidayRunningParser
    {
        [TestFixture]
        class ParseBankHolidayRunning
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var parser = new BankHolidayRunningParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseBankHolidayRunning(null));
            }

            [Test]
            public void returns_false_when_string_is_falsey_value()
            {
                var parser = new BankHolidayRunningParser();

                var result = parser.ParseBankHolidayRunning("X");
                Assert.AreEqual(BankHolidayRunning.DoesNotRun, result);

                result = parser.ParseBankHolidayRunning("G");
                Assert.AreEqual(BankHolidayRunning.DoesNotRunGlasgow, result);
            }

            [Test]
            public void returns_true_when_string_is_truthy_value()
            {
                var parser = new BankHolidayRunningParser();

                var result = parser.ParseBankHolidayRunning(string.Empty);
                Assert.AreEqual(BankHolidayRunning.RunsOnBankHoliday, result);
            }
        }
    }
}