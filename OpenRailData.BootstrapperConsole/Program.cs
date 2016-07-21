using System.Threading.Tasks;
using OpenRailData.BootstrapperJobs;
using OpenRailData.Darwin;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json;
using OpenRailData.ScheduleStorage.EntityFramework;
using Autofac;

namespace OpenRailData.BootstrapperConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var containerBuilder = DarwinModuleContainerBuilder.Build();
            containerBuilder = EntityFrameworkScheduleStorageContainerBuilder.Build(containerBuilder);
            containerBuilder = ScheduleModuleContainerBuilder.Build(containerBuilder);
            containerBuilder = JsonScheduleParsingContainerBuilder.Build(containerBuilder);
            containerBuilder = BootstrapperJobsContainerBuilder.Build(containerBuilder);

            var container = containerBuilder.Build();

            var darwinLocationDataJob = container.Resolve<IDarwinLocationDataBootstrapperJob>();
            var scheduleDataJob = container.Resolve<INetworkRailScheduleDataBootstrapperJob>();

            Task.Run(() => scheduleDataJob.Execute()).Wait();
            Task.Run(() => darwinLocationDataJob.Execute()).Wait();
        }
    }
}
