using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
{
    [TestFixture]
    public class TLocationActivityParser
    {
        [TestFixture]
        class ParseLocationActivity
        {
            [Test]
            public void throws_if_argument_string_is_empty()
            {
                var parser = new LocationActivityParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseActivity(null));
            }
        }
    }
}