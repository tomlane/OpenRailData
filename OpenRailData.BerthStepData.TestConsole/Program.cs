using System;
using Microsoft.Practices.Unity;
using OpenRailData.DataFetcher;
using OpenRailData.TrainDescriberParsing;
using OpenRailData.TrainDescriberParsing.Json;
using OpenRailData.TrainDescriberParsing.Json.TrainDescriberMessageParsers;

namespace OpenRailData.BerthStepData.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            var request = new[]
            {
                @"{""SF_MSG"":{""time"":""1422404915000"",""area_id"":""SI"",""address"":""16"",""msg_type"":""SF"",""data"":""43""}}",
                @"{""SG_MSG"":{""time"":""1422404915000"",""area_id"":""RW"",""address"":""00"",""msg_type"":""SG"",""data"":""06880306""}}",
                @"{""SH_MSG"":{""time"":""1422404915000"",""area_id"":""RW"",""address"":""04"",""msg_type"":""SH"",""data"":""35000000""}}",
                @"{""CA_MSG"":{""time"":""1349696911000"", ""area_id"":""SK"", ""msg_type"":""CA"", ""from"":""3647"", ""to"":""3649"", ""descr"":""1F42""}}",
                @"{""CB_MSG"":{""time"":""1349696911000"", ""area_id"":""G1"", ""msg_type"":""CB"", ""from"":""G669"", ""descr"":""2J01""}}",
                @"{""CC_MSG"":{""time"":""1349696911000"", ""area_id"":""G1"", ""msg_type"":""CC"", ""descr"":""2J01"", ""to"":""G669""}}"
            };

            var parsingService = container.Resolve<ITrainDescriberMessageParsingService>();

            var result = parsingService.ParseDescriberMessages(request);

            foreach (var trainDescriberMessage in result)
            {
                Console.WriteLine(trainDescriberMessage);
            }

            Console.ReadLine();
        }

        private static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBerthStepDataProvider, BerthStepDataProvider>();

            container.RegisterType<IDataFileFetcher, FileSystemDataFileFetcher>();
            container.RegisterType<IDataFileDecompressor, GzipDataFileDecompressor>();

            container.RegisterType<ITrainDescriberMessageParsingService, TrainDescriberMessageParsingService>();

            container.RegisterType<ITrainDescriberMessageParser, BerthCancelMessageParser>("BerthCancelMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, BerthInterposeMessageParser>("BerthInterposeMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, BerthStepMessageParser>("BerthStepMessageParser");

            container.RegisterType<ITrainDescriberMessageParser, SignallingUpdateMessageParser>("SignallingUpdateMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, SignallingRefreshMessageParser>("SignallingRefreshMessageParser");
            container.RegisterType<ITrainDescriberMessageParser, SignallingRefreshFinishedMessageParser>("SignallingRefreshFinishedMessageParser");

            return container;
        }
    }
}
