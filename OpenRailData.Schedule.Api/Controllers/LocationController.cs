using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRailData.Schedule.Api.ResponseModels;
using OpenRailData.Schedule.Entities;
using System.Linq;
using OpenRailData.Schedule.Api.BindingModels;
using OpenRailData.Schedule.Api.Presenters;

namespace OpenRailData.Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly IScheduleProvider _scheduleProvider;

        public LocationController(IScheduleProvider scheduleProvider)
        {
            if (scheduleProvider == null)
                throw new ArgumentNullException(nameof(scheduleProvider));

            _scheduleProvider = scheduleProvider;
        }

        [HttpPost("Search")]
        public async Task<List<ScheduleLocationSearchResponseModel>> SearchScheduleLocations([FromBody]ScheduleLocationSearchBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var providerResponse = await _scheduleProvider.GetScheduleLocationsByTiploc(model.Tiploc);

            return providerResponse.Select(ScheduleLocationRecordPresenter.PresentScheduleLocationRecord).ToList();
        }
    }
}