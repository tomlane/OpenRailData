using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.Schedule
{
    public class TiplocEditor : ITiplocEditor
    {
        private readonly IScheduleUnitOfWorkFactory _unitOfWorkFactory;

        public TiplocEditor(IScheduleUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));

            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task UpdateTiplocLocationName(AmendTiplocLocationNameRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var tiploc = await unitOfWork.TiplocRecords.GetTiplocByTiplocCode(request.TiplocCode);

                if (tiploc != null)
                {
                    tiploc.LocationName = request.LocationName;

                    await unitOfWork.TiplocRecords.AmendRecord(tiploc);

                    await unitOfWork.Complete();
                }
            }
        }

        public async Task UpdateTiplocLocationName(IEnumerable<AmendTiplocLocationNameRequest> requests)
        {
            if (requests == null)
                throw new ArgumentNullException(nameof(requests));

            foreach (var amendTiplocLocationNameRequest in requests)
            {
                await UpdateTiplocLocationName(amendTiplocLocationNameRequest);
            }
        }
    }
}