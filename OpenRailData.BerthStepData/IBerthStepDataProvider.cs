using System.Collections.Generic;
using OpenRailData.Domain.ReferenceData;

namespace OpenRailData.BerthStepData
{
    public interface IBerthStepDataProvider
    {
        IList<BerthStep> GetBerthSteps();
    }
}