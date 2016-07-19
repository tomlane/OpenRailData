using System.Collections.Generic;
using OpenRailData.BerthStepData.Entites;

namespace OpenRailData.BerthStepData
{
    public interface IBerthStepDataProvider
    {
        IList<BerthStep> GetBerthSteps();
    }
}