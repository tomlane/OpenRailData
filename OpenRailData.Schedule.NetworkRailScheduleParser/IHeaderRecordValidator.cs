using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IHeaderRecordValidator
    {
        HeaderRecordValidationResult ValidateHeaderRecord(HeaderRecordValidationRequest request);
    }

    public class HeaderRecordValidationRequest
    {
        public HeaderRecord RecordToCheck { get; set; }
    }

    public class HeaderRecordValidationResult
    {
        public bool IsValid { get; set; }
    }
}