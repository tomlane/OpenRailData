﻿using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result_when_valid()
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseProperty("JJ");
                Assert.AreEqual(AssociationCategory.JJ, result);

                result = parser.ParseProperty("VV");
                Assert.AreEqual(AssociationCategory.VV, result);

                result = parser.ParseProperty("NP");
                Assert.AreEqual(AssociationCategory.NP, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseProperty("XYZ");
                Assert.AreEqual(AssociationCategory.None, result);

            }
        }
    }
}