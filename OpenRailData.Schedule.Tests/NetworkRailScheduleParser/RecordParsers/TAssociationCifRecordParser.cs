using System;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TAssociationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        [SetUp]
        public void Setup()
        {
            _container = CifParserIocContainerBuilder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        private static AssociationCifRecordParser BuildParser()
        {
            return new AssociationCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            var enumRecordParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new AssociationCifRecordParser(null, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationCifRecordParser(enumRecordParsers, null));
        }


        [Test]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_expected_result_with_revise_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AARW01400W005701512131602070000001   ORPNGTN  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAR,
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

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_result_with_new_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AANL82468L839221512191601020000010   CLCHSTR  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAN,
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

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_result_with_delete_record()
        {
            var recordParser = BuildParser();
            var recordToParse = "AADL82468L83922151226                CLCHSTR  T                                C";
            var expectedResult = new AssociationRecord
            {
                RecordIdentity = ScheduleRecordType.AAD,
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

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}