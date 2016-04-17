using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleValidation
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