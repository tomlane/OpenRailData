using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IHeaderRecordParserContainer
    {
        IDateTimeParser DateTimeParser { get; }
        IExtractUpdateTypeParser UpdateTypeParser { get; }
        ITimeParser TimeParser { get; }
    }
}