using System.Collections.Generic;
using OpenRailData.TrainDescriber.Entities;

namespace OpenRailData.TrainDescriber.TrainDescriberParsing
{
    public interface ITrainDescriberMessageParsingService
    {
        IEnumerable<ITrainDescriberMessage> ParseDescriberMessages(IEnumerable<string> messages);
    }
}