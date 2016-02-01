using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using OpenRailData.Schedule.DependencyInjection;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.Records.NetworkRail;

namespace NetworkRail.CifParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\RailData\Cif Schedule Extracts\weekly-150116";

            var start = Process.GetCurrentProcess().TotalProcessorTime;

            var container = CifParserIocContainerBuilder.Build();

            var scheduleManager = container.Resolve<IScheduleManager>();

            List<IScheduleRecord> entites = scheduleManager.ParseScheduleRecords(path).ToList();
            
            var end = Process.GetCurrentProcess().TotalProcessorTime;

            System.Console.WriteLine("Record Parsing Time: {0} ms.", (end - start).TotalMilliseconds);
            System.Console.WriteLine("Records Parsed: {0}", entites.Count);

            start = Process.GetCurrentProcess().TotalProcessorTime;

            entites = scheduleManager.MergeScheduleRecords(entites).ToList();

            end = Process.GetCurrentProcess().TotalProcessorTime;

            System.Console.WriteLine("Record Merging Time: {0} ms.", (end - start).TotalMilliseconds);
            System.Console.WriteLine("Merged Records Count: {0}", entites.Count);

            System.Console.ReadLine();
        }
    }
}
