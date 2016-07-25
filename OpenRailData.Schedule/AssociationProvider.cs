using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;
using System.Linq;

namespace OpenRailData.Schedule
{
    public class AssociationProvider : IAssociationProvider
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public AssociationProvider(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<AssociationRecord> GetAssociationByMainTrainUid(string mainTrainId, string location)
        {
            if (string.IsNullOrWhiteSpace(mainTrainId))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(mainTrainId));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(location));

            List<AssociationRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.AssociationRecords.FindByMainTrainUid(mainTrainId, location);
            }

            return records.First();
        }

        public async Task<AssociationRecord> GetAssociationByAssocTrainUid(string assocTrainId, string location)
        {
            if (string.IsNullOrWhiteSpace(assocTrainId))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(assocTrainId));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(location));

            List<AssociationRecord> records;

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                records = await unitOfWork.AssociationRecords.FindByAssocTrainUid(assocTrainId, location);
            }

            return records.First();
        }
    }
}