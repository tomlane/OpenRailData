using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface ILocationRecordParserContainer
    {
        ILocationTypeParser LocationTypeParser { get; } 
        ITimeParser TimeParser { get; }
        ILocationActivityParser LocationActivityParser { get; }
    }
}