using Microsoft.Practices.Unity;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;

namespace OpenRailData.TrainMovementParsing.Json
{
    public static class JsonTrainMovementParserContainerBuilder
    {
        public static IUnityContainer Build(IUnityContainer container = null)
        {
            if (container == null)
                container = new UnityContainer();

            container.RegisterType<ITrainMovementParsingService, TrainMovementParsingService>();

            container.RegisterType<ITrainMovementMessageParser, TrainActivationMessageParser>("TrainActivationMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainCancellationMessageParser>("TrainCancellationMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainMovementMessageParser>("TrainMovementMessageParser");
            container.RegisterType<ITrainMovementMessageParser, TrainReinstatementMessageParser>("TrainReinstatementMessageParser");
            container.RegisterType<ITrainMovementMessageParser, ChangeOfIdentityMessageParser>("ChangeOfIdentityMessageParser");
            container.RegisterType<ITrainMovementMessageParser, ChangeOfOriginMessageParser>("ChangeOfOriginMessageParser");

            return container;
        }
    }
}