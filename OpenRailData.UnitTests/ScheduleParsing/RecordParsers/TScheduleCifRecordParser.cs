using System;
using Microsoft.Practices.Unity;
using Moq;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleContainer;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TScheduleCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static IDateTimeParser _dateTimeParser;

        public TScheduleCifRecordParser()
        {
            _container = CifParserIocContainerBuilder.Build();

            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
            _dateTimeParser = _container.Resolve<IDateTimeParser>();
        }

        private ScheduleCifRecordParser BuildParser()
        {
            return new ScheduleCifRecordParser(_enumPropertyParsers, _dateTimeParser);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(enumPropertyParsers, null));
            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(null, dateTimeParserMock.Object));
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Fact(Skip = "Needs a better check and record")]
        public void returns_expected_result_with_permanent_record()
        {
        }
    }
}