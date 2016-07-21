using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenRailData.Schedule
{
    public interface ITiplocEditor
    {
        Task UpdateTiplocLocationName(AmendTiplocLocationNameRequest request);
        Task UpdateTiplocLocationName(IEnumerable<AmendTiplocLocationNameRequest> requests);
    }
}