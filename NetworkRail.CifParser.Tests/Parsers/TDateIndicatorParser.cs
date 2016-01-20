﻿using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TDateIndicatorParser
    {
        [TestFixture]
        class ParseDateIndicator
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new DateIndicatorParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseDateIndicator(null));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new DateIndicatorParser();

                var result = parser.ParseDateIndicator("S");
                Assert.AreEqual(DateIndicator.Standard, result);

                result = parser.ParseDateIndicator("N");
                Assert.AreEqual(DateIndicator.Overnight, result);

                result = parser.ParseDateIndicator("P");
                Assert.AreEqual(DateIndicator.PreviousNight, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new DateIndicatorParser();

                var result = parser.ParseDateIndicator("ZZZ");

                Assert.AreEqual(DateIndicator.None, result);
            }
        }
    }
}