using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRailData.Schedule.Api.BindingModels;
using OpenRailData.Schedule.Api.Presenters;
using OpenRailData.Schedule.Api.ResponseModels;

namespace OpenRailData.Schedule.Api.Controllers
{
    [Route("api/[controller]")]
    public class AssociationController : Controller
    {
        private readonly IAssociationProvider _associationProvider;

        public AssociationController(IAssociationProvider associationProvider)
        {
            if (associationProvider == null)
                throw new ArgumentNullException(nameof(associationProvider));

            _associationProvider = associationProvider;
        }

        [HttpPost("Search")]
        public async Task<AssociationSearchResponseModel> SearchByMainTrainUid([FromBody]AssociationMainTrainUidSearchBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var providerResponse = await _associationProvider.GetAssociationByMainTrainUid(model.MainTrainUid, model.Location);

            return AssociationRecordPresenter.PresentSearchResponse(providerResponse);
        }
    }
}