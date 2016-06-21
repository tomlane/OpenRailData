using System;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Schedule;

namespace OpenRailData.MessageProcessing.ActivationProcessors
{
    public class ActivationJourneyProcessor : ITrainMovementMessageProcessor
    {
        private readonly IScheduleProvider _scheduleProvider;

        public ActivationJourneyProcessor(IScheduleProvider scheduleProvider)
        {
            if (scheduleProvider == null)
                throw new ArgumentNullException(nameof(scheduleProvider));

            _scheduleProvider = scheduleProvider;
        }

        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainActivation;

        public Task ProcessMessage(ITrainMovementMessage message)
        {
            throw new NotImplementedException();
        }
    }
}