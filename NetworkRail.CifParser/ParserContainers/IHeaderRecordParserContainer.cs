using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IHeaderRecordParserContainer
    {
        IDateTimeParser DateTimeParser { get; set; }
        IExtractUpdateTypeParser UpdateTypeParser { get; set; }
        ITimeParser TimeParser { get; set; }
    }
}