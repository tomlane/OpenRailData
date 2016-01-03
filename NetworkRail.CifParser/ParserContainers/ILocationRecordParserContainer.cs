using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface ILocationRecordParserContainer
    {
        ILocationTypeParser LocationTypeParser { get; set; } 
        ILocationTimeParser LocationTimeParser { get; set; }
        ITimingAllowanceParser TimingAllowanceParser { get; set; }
        ILocationActivityParser LocationActivityParser { get; set; }
    }
}