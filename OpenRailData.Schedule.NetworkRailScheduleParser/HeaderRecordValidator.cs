using System;
using Common.Logging;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class HeaderRecordValidator : IHeaderRecordValidator
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ILog Logger = LogManager.GetLogger("Schedule.Util.HeaderRecordValidator");

        public HeaderRecordValidator(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public HeaderRecordValidationResult ValidateHeaderRecord(HeaderRecordValidationRequest request)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Validating Schedule Header Record.");

            if (request?.RecordToCheck == null)
                throw new ArgumentNullException(nameof(request));

            var headerRecord = request.RecordToCheck;

            var response = new HeaderRecordValidationResult();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var previousUpdate = unitOfWork.HeaderRecords.GetPreviousUpdate();

                if (previousUpdate != null)
                {
                    if (headerRecord.DateOfExtract <= previousUpdate.DateOfExtract)
                        throw new InvalidOperationException(
                            $"The schedule file is out of order. Previous update date: {previousUpdate.DateOfExtract}. Attempted update date: {headerRecord.DateOfExtract}");

                    if (previousUpdate.ExtractUpdateType != ExtractUpdateType.U)
                        return response;

                    if (previousUpdate.CurrentFileRef != headerRecord.LastFileRef)
                        throw new InvalidOperationException($"The schedule file is out of order. Last file reference: {previousUpdate.CurrentFileRef}. Expected Last file reference: {headerRecord.LastFileRef}");
                }
            }

            if (Logger.IsInfoEnabled)
                Logger.Info("Finished validating Schedule Header Record. Header is valid.");

            response.IsValid = true;

            return response;
        }
    }
}