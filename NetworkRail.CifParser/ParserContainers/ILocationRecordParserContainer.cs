using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface ILocationRecordParserContainer
    {
        ILocationTypeParser LocationTypeParser { get; set; } 
        ITimeParser TimeParser { get; set; }
        ILocationActivityParser LocationActivityParser { get; set; }
    }
}