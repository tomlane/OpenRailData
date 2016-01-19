using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.Unity;
using NetworkRail.CifParser.IoC;

namespace NetworkRail.CifParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\RailData\Cif Schedule Extracts\weekly-150116";

            var start = Process.GetCurrentProcess().TotalProcessorTime;

            var container = CifParserIocContainerBuilder.Build();

            var updateProcessor = container.Resolve<IScheduleUpdateProcessor>();

            CifScheduleRecordCollection entites;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                entites = updateProcessor.ParseScheduleUpdate(fs);
            }
            
            var end = Process.GetCurrentProcess().TotalProcessorTime;

            System.Console.WriteLine("Measured Time: {0} ms.", (end - start).TotalMilliseconds);
            System.Console.WriteLine("Schedule date: {0}", entites.HeaderRecord.DateOfExtract);

            System.Console.ReadLine();
        }
    }
}
