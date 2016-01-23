using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface ILocationRecordParserContainer
    {
        ITimeParser TimeParser { get; }
        ILocationActivityParser LocationActivityParser { get; }
    }
}