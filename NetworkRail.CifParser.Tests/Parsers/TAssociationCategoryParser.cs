using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TAssociationCategoryParser
    {
        [TestFixture]
        class ParseAssociationCategory
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new AssociationCategoryParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseAssociationCategory(null));
            }

            [Test]
            public void returns_expected_result_when_valid()
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseAssociationCategory("JJ");
                Assert.AreEqual(AssociationCategory.Join, result);

                result = parser.ParseAssociationCategory("VV");
                Assert.AreEqual(AssociationCategory.Split, result);

                result = parser.ParseAssociationCategory("NP");
                Assert.AreEqual(AssociationCategory.Next, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseAssociationCategory("XYZ");
                Assert.AreEqual(AssociationCategory.None, result);

            }
        }
    }
}