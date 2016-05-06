using System;
using Microsoft.Practices.Unity;
using OpenRailData.DataFetcher;

namespace OpenRailData.BerthStepData.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            var provider = container.Resolve<IBerthStepDataProvider>();

            var data = provider.GetBerthSteps();

            Console.ReadLine();
        }

        private static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBerthStepDataProvider, BerthStepDataProvider>();

            container.RegisterType<IDataFileFetcher, FileSystemDataFileFetcher>();
            container.RegisterType<IDataFileDecompressor, GzipDataFileDecompressor>();

            return container;
        }
    }
}
