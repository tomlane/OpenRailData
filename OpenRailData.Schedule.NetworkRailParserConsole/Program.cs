using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using OpenRailData.Schedule.NetworkRailScheduleParser;

namespace OpenRailData.Schedule.NetworkRailParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.TraceInformation("Starting up...");

            var start = Process.GetCurrentProcess().TotalProcessorTime;

            var container = CifParserIocContainerBuilder.Build();
            Trace.TraceInformation("Dependency Injection container built.");

            var scheduleManager = container.Resolve<IScheduleManager>();

            var entites = scheduleManager.GetWeeklyScheduleRecords().ToList();
            
            var end = Process.GetCurrentProcess().TotalProcessorTime;

            Trace.TraceInformation("Record Parsing Time: {0} ms.", (end - start).TotalMilliseconds);
            Trace.TraceInformation("Records Parsed: {0}", entites.Count);

            start = Process.GetCurrentProcess().TotalProcessorTime;

            entites = scheduleManager.MergeScheduleRecords(entites).ToList();

            end = Process.GetCurrentProcess().TotalProcessorTime;

            Trace.TraceInformation("Record Merging Time: {0} ms.", (end - start).TotalMilliseconds);
            Trace.TraceInformation("Merged Records Count: {0}", entites.Count);

            Trace.TraceInformation("Schedule record processing complete. Ready for storage.");

            start = Process.GetCurrentProcess().TotalProcessorTime;

            scheduleManager.SaveScheduleRecords(entites);

            end = Process.GetCurrentProcess().TotalProcessorTime;

            Trace.TraceInformation("Schedule storage complete.");
            Trace.TraceInformation("Storage Processing Time: {0} ms.", (end - start).TotalMilliseconds);

            Trace.TraceInformation("Press any key to close...");

            Console.ReadLine();
        }
    }
}
