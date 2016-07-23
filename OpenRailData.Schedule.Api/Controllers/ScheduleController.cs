using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRailData.Schedule.Api.BindingModels;
using OpenRailData.Schedule.Api.Presenters;
using OpenRailData.Schedule.Api.ResponseModels;

namespace OpenRailData.Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleProvider _scheduleProvider;

        public ScheduleController(IScheduleProvider scheduleProvider)
        {
            if (scheduleProvider == null)
                throw new ArgumentNullException(nameof(scheduleProvider));

            _scheduleProvider = scheduleProvider;
        }

        [HttpPost("Search")]
        public async Task<ScheduleRecordSearchResponseModel> SearchSchedules([FromBody]ScheduleRecordSearchBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var providerResponse = await _scheduleProvider.GetScheduleRecord(model.TrainUid, model.ScheduleStartDate);

            var responseModel = ScheduleRecordPresenter.PresentScheduleRecord(providerResponse);

            return responseModel;
        }
    }
}
