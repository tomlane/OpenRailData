using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface ILocationRecordParserContainer
    {
        ILocationTypeParser LocationTypeParser { get; } 
        ITimeParser TimeParser { get; }
        ILocationActivityParser LocationActivityParser { get; }
    }
}