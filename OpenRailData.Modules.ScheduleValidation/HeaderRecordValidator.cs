using System;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleStorage;
using OpenRailData.ScheduleValidation;

namespace OpenRailData.Modules.ScheduleValidation
{
    public class HeaderRecordValidator : IHeaderRecordValidator
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public HeaderRecordValidator(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public HeaderRecordValidationResult ValidateHeaderRecord(HeaderRecordValidationRequest request)
        {
            if (request?.RecordToCheck == null)
                throw new ArgumentNullException(nameof(request));

            var headerRecord = request.RecordToCheck as HeaderRecord;

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

            response.IsValid = true;

            return response;
        }
    }
}