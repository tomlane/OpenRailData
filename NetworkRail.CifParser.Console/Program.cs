using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\RailData\Cif\update-28122015";

            var start = Process.GetCurrentProcess().TotalProcessorTime;

            var container = CifParserIocContainerBuilder.Build();

            var scheduleManager = container.Resolve<IScheduleManager>();

            List<ICifRecord> entites;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                entites = scheduleManager.ParseScheduleEntites(fs).ToList();
            }
            
            var end = Process.GetCurrentProcess().TotalProcessorTime;

            System.Console.WriteLine("Measured Time: {0} ms.", (end - start).TotalMilliseconds);
            System.Console.WriteLine("Records Processed: {0}", entites.Count);

            System.Console.ReadLine();
        }
    }
}
