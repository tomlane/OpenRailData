using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
{
    [TestFixture]
    public class TLocationActivityParser
    {
        [TestFixture]
        class ParseLocationActivity
        {
            [Test]
            public void throws_if_argument_string_is_null()
            {
                var parser = new LocationActivityParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new LocationActivityParser();

                string activities = "A AEBLC D -DE G H HHK KCKEKFKSL N OPORPRR RMRRS T -TTBTFTSTWU -UW X ";

                var result = parser.ParseProperty(activities);
                
                Assert.IsTrue(result.HasFlag(LocationActivity.A));
                Assert.IsTrue(result.HasFlag(LocationActivity.AE));
                Assert.IsTrue(result.HasFlag(LocationActivity.AX));
                Assert.IsTrue(result.HasFlag(LocationActivity.BL));
                Assert.IsTrue(result.HasFlag(LocationActivity.C));
                Assert.IsTrue(result.HasFlag(LocationActivity.D));
                Assert.IsTrue(result.HasFlag(LocationActivity.MinusD));
                Assert.IsTrue(result.HasFlag(LocationActivity.E));
                Assert.IsTrue(result.HasFlag(LocationActivity.G));
                Assert.IsTrue(result.HasFlag(LocationActivity.H));
                Assert.IsTrue(result.HasFlag(LocationActivity.HH));
                Assert.IsTrue(result.HasFlag(LocationActivity.K));
                Assert.IsTrue(result.HasFlag(LocationActivity.KC));
                Assert.IsTrue(result.HasFlag(LocationActivity.KE));
                Assert.IsTrue(result.HasFlag(LocationActivity.KF));
                Assert.IsTrue(result.HasFlag(LocationActivity.KS));
                Assert.IsTrue(result.HasFlag(LocationActivity.L));
                Assert.IsTrue(result.HasFlag(LocationActivity.N));
                Assert.IsTrue(result.HasFlag(LocationActivity.OP));
                Assert.IsTrue(result.HasFlag(LocationActivity.OR));
                Assert.IsTrue(result.HasFlag(LocationActivity.PR));
                Assert.IsTrue(result.HasFlag(LocationActivity.R));
                Assert.IsTrue(result.HasFlag(LocationActivity.RM));
                Assert.IsTrue(result.HasFlag(LocationActivity.RR));
                Assert.IsTrue(result.HasFlag(LocationActivity.S));
                Assert.IsTrue(result.HasFlag(LocationActivity.T));
                Assert.IsTrue(result.HasFlag(LocationActivity.MinusT));
                Assert.IsTrue(result.HasFlag(LocationActivity.TB));
                Assert.IsTrue(result.HasFlag(LocationActivity.TF));
                Assert.IsTrue(result.HasFlag(LocationActivity.TS));
                Assert.IsTrue(result.HasFlag(LocationActivity.TW));
                Assert.IsTrue(result.HasFlag(LocationActivity.U));
                Assert.IsTrue(result.HasFlag(LocationActivity.MinusU));
                Assert.IsTrue(result.HasFlag(LocationActivity.W));
                Assert.IsTrue(result.HasFlag(LocationActivity.X));
            }
        }
    }
}