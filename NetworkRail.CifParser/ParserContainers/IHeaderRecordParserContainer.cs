using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IHeaderRecordParserContainer
    {
        IDateTimeParser DateTimeParser { get; }
        IExtractUpdateTypeParser UpdateTypeParser { get; }
        ITimeParser TimeParser { get; }
    }
}