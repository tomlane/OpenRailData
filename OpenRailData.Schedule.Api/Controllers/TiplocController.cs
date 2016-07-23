using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRailData.Schedule.Api.Presenters;
using OpenRailData.Schedule.Api.ResponseModels;

namespace OpenRailData.Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class TiplocController : Controller
    {
        private readonly ITiplocProvider _tiplocProvider;

        public TiplocController(ITiplocProvider tiplocProvider)
        {
            if (tiplocProvider == null)
                throw new ArgumentNullException(nameof(tiplocProvider));

            _tiplocProvider = tiplocProvider;
        }

        /// <summary>
        /// Gets a Tiploc record by crs code.
        /// </summary>
        /// <param name="crs">The crs code.</param>
        /// <returns>An instance of <see cref="TiplocRecordResponseModel"/>.</returns>
        [HttpGet("{crs}")]
        public async Task<TiplocRecordResponseModel> GetTiploc(string crs)
        {
            if (string.IsNullOrWhiteSpace(crs))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(crs));

            var providerResponse = await _tiplocProvider.GetTiplocByCrs(crs);
            
            return TiplocRecordPresenter.PresentTiplocRecord(providerResponse);
        }
    }
}