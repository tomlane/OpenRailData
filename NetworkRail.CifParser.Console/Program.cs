using System;
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
            string path = @"C:\RailData\Cif\update-31122015";

            var container = CifParserIocContainerBuilder.Build();

            var cifRecordParser = container.Resolve<ICifRecordParser>();
            var parsedCifRecords = new List<ICifRecord>();

            TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    parsedCifRecords.Add(cifRecordParser.ParseRecord(record));
                }
            }

            TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;

            var headers = parsedCifRecords.OfType<HeaderRecord>();
            var associations = parsedCifRecords.OfType<AssociationRecord>();
            var basicSchedules = parsedCifRecords.OfType<BasicScheduleRecord>();
            var extraDetails = parsedCifRecords.OfType<BasicScheduleExtraDetailsRecord>();
            var locations = parsedCifRecords.OfType<LocationRecord>();
           

            System.Console.WriteLine("Records Parsed: {0}", parsedCifRecords.Count);
            System.Console.WriteLine("Measured Time: {0} ms.", (end - start).TotalMilliseconds);

            System.Console.ReadLine();
        }
    }
}
