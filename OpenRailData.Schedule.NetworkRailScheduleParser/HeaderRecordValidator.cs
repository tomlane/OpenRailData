using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Common.Logging;
using OpenRailData.Schedule.DataAccess.EntityFramework;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public class HeaderRecordValidator : IHeaderRecordValidator
    {
        private readonly IDbContextFactory<ScheduleContext> _contextFactory;
        private readonly ILog Logger = LogManager.GetLogger("Schedule.Util.HeaderRecordValidator");

        public HeaderRecordValidator(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public HeaderRecordValidationResult ValidateHeaderRecord(HeaderRecordValidationRequest request)
        {
            if (Logger.IsInfoEnabled)
                Logger.Info("Validating Schedule Header Record.");

            if (request?.RecordToCheck == null)
                throw new ArgumentNullException(nameof(request));

            var headerRecord = request.RecordToCheck;

            var response = new HeaderRecordValidationResult();

            using (var unitOfWork = new ScheduleUnitOfWork(_contextFactory.Create()))
            {
                var previousUpdate = unitOfWork.HeaderRecords.GetRecentUpdates().FirstOrDefault();

                if (headerRecord.DateOfExtract <= previousUpdate.DateOfExtract)
                    throw new InvalidOperationException(
                        $"The schedule file is out of order. Previous update date: {previousUpdate.DateOfExtract}. Attempted update date: {headerRecord.DateOfExtract}");

                if (previousUpdate.ExtractUpdateType != ExtractUpdateType.U)
                    return response;

                if (previousUpdate.CurrentFileRef != headerRecord.LastFileRef)
                    throw new InvalidOperationException($"The schedule file is out of order. Last file reference: {previousUpdate.CurrentFileRef}. Expected Last file reference: {headerRecord.LastFileRef}");
            }

            if (Logger.IsInfoEnabled)
                Logger.Info("Finished validating Schedule Header Record. Header is valid.");

            response.IsValid = true;

            return response;
        }
    }
}