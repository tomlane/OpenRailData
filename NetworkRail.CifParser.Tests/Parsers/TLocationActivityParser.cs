using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseActivity(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new LocationActivityParser();

                string activities = "A AEBLC D -DE G H HHK KCKEKFKSL N OPORPRR RMRRS T -TTBTFTSTWU -UW X ";

                var result = parser.ParseActivity(activities);

                Assert.IsTrue(result.A);
                Assert.IsTrue(result.Ae);
                Assert.IsTrue(result.Bl);
                Assert.IsTrue(result.C);
                Assert.IsTrue(result.D);
                Assert.IsTrue(result.MinusD);
                Assert.IsTrue(result.E);
                Assert.IsTrue(result.G);
                Assert.IsTrue(result.H);
                Assert.IsTrue(result.Hh);
                Assert.IsTrue(result.K);
                Assert.IsTrue(result.Kc);
                Assert.IsTrue(result.Ke);
                Assert.IsTrue(result.Kf);
                Assert.IsTrue(result.Ks);
                Assert.IsTrue(result.L);
                Assert.IsTrue(result.N);
                Assert.IsTrue(result.Op);
                Assert.IsTrue(result.Or);
                Assert.IsTrue(result.Pr);
                Assert.IsTrue(result.R);
                Assert.IsTrue(result.Rm);
                Assert.IsTrue(result.Rr);
                Assert.IsTrue(result.S);
                Assert.IsTrue(result.T);
                Assert.IsTrue(result.MinusT);
                Assert.IsTrue(result.Tb);
                Assert.IsTrue(result.Tf);
                Assert.IsTrue(result.Ts);
                Assert.IsTrue(result.Tw);
                Assert.IsTrue(result.U);
                Assert.IsTrue(result.MinusU);
                Assert.IsTrue(result.W);
                Assert.IsTrue(result.X);
            }
        }
    }
}