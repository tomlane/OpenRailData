using System;
using Microsoft.Practices.Unity;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.IntegrationTests.ScheduleParsing.RecordParsers
{
    public class THeaderCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        public THeaderCifRecordParser()
        {
            _container = SchedulePropertyParsersContainerBuilder.Build();
            _container = CifScheduleParsingContainerBuilder.Build(_container);

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        private static HeaderCifRecordParser BuildParser()
        {
            return new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "HDTPS.UDFROC1.PD1512303012152116DFROC1EDFROC1DUA301215291216                    ";
            var expectedResult = new HeaderRecord
            {
                RecordIdentity = ScheduleRecordType.HD,
                MainFrameIdentity = "TPS.UDFROC1.PD151230",
                DateOfExtract = new DateTime(2015, 12, 30),
                TimeOfExtract = "2116",
                CurrentFileRef = "DFROC1E",
                LastFileRef = "DFROC1D",
                ExtractUpdateType = ExtractUpdateType.U,
                CifSoftwareVersion = "A",
                UserExtractStartDate = new DateTime(2015, 12, 30),
                UserExtractEndDate = new DateTime(2016, 12, 29),
                MainFrameUser = "DFROC1",
                MainFrameExtractDate = new DateTime(2015, 12, 30)
            };

            var result = recordParser.ParseRecord(recordToParse);

            Assert.Equal(expectedResult, result);
        }
    }
}