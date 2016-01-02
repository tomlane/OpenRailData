using System;
using NetworkRail.CifParser.RecordBuilders;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TTiplocDeleteRecordBuilder
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new TiplocDeleteRecordBuilder();

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                Assert.Inconclusive("Need to find an example Tiploc Delete record.");
            }
        }
    }
}