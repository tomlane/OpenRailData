using System.Collections.Generic;
using OpenRailData.Domain.TrainDescriber;

namespace OpenRailData.TrainDescriberParsing
{
    public interface ITrainDescriberMessageParsingService
    {
        IEnumerable<ITrainDescriberMessage> ParseDescriberMessages(IEnumerable<string> messages);
    }
}