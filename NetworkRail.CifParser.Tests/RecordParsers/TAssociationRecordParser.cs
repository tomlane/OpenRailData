﻿using System;
using Microsoft.Practices.Unity;
using Moq;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TAssociationRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        [OneTimeSetUp]
        public void ContainerSetup()
        {
            _container = CifParserIocContainerBuilder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumRecordParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParser(null, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationRecordParser(enumRecordParsers, null));
        }

        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new AssociationRecordParser(_enumPropertyParsers, _dateTimeParser);

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_revise_record()
            {
                var recordParser = new AssociationRecordParser(_enumPropertyParsers, _dateTimeParser);

                string recordToParse = "AARW01400W005701512131602070000001   ORPNGTN  T                                C";

                var result = recordParser.ParseRecord(recordToParse);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = TransactionType.R,
                    MainTrainUid = "W01400",
                    AssocTrainUid = "W00570",
                    DateFrom = new DateTime(2015, 12, 13),
                    DateTo = new DateTime(2016, 2, 7),
                    AssocDays = Days.Sunday,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "ORPNGTN",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_with_new_record()
            {
                var recordParser = new AssociationRecordParser(_enumPropertyParsers, _dateTimeParser);

                string record = "AANL82468L839221512191601020000010   CLCHSTR  T                                C";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = TransactionType.N,
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = new DateTime(2015, 12, 19),
                    DateTo = new DateTime(2016, 1, 2),
                    AssocDays = Days.Saturday,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_with_delete_record()
            {
                var recordParser = new AssociationRecordParser(_enumPropertyParsers, _dateTimeParser);

                string record = "AADL82468L83922151226                CLCHSTR  T                                C";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new AssociationRecord
                {
                    TransactionType = TransactionType.D,
                    MainTrainUid = "L82468",
                    AssocTrainUid = "L83922",
                    DateFrom = new DateTime(2015, 12, 26),
                    DateTo = null,
                    Category = AssociationCategory.None,
                    DateIndicator = DateIndicator.None,
                    Location = "CLCHSTR",
                    BaseLocationSuffix = string.Empty,
                    AssocLocationSuffix = string.Empty,
                    DiagramType = "T",
                    AssocType = AssociationType.None,
                    StpIndicator = StpIndicator.C
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}