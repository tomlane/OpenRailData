using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NetworkRail.CifParser.Entities;

namespace NetworkRail.CifParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"CIF FILE PATH";

            var parsedCifRecords = new List<ICifRecord>();

            TimeSpan start = Process.GetCurrentProcess().TotalProcessorTime;

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string record;
                while ((record = sr.ReadLine()) != null)
                {
                    string recordType = record.Substring(0, 2);

                    switch (recordType)
                    {
                        case "HD":
                            parsedCifRecords.Add(new HeaderRecord(record));
                            break;
                        case "TI":
                            parsedCifRecords.Add(new TiplocInsertAmendRecord(record));
                            break;
                        case "TA":
                            parsedCifRecords.Add(new TiplocInsertAmendRecord(record));
                            break;
                        case "AA":
                            parsedCifRecords.Add(new AssociationRecord(record));
                            break;
                        case "BS":
                            parsedCifRecords.Add(new BasicScheduleRecord(record));
                            break;
                        case "BX":
                            var scheduleRecord = parsedCifRecords.Last() as BasicScheduleRecord;

                            if (scheduleRecord == null)
                                throw new InvalidOperationException("The Schedule Record record to merge was not found.");

                            scheduleRecord.MergeExtraScheduleDetails(record);
                            break;
                        case "LO":
                            parsedCifRecords.Add(new LocationRecord(record));
                            break;
                        case "LI":
                            parsedCifRecords.Add(new LocationRecord(record));
                            break;
                        case "CR":
                            parsedCifRecords.Add(new ChangesEnRouteRecord(record));
                            break;
                        case "LT":
                            parsedCifRecords.Add(new LocationRecord(record));
                            break;
                        case "ZZ":
                            break;
                        default:
                            throw new NotImplementedException($"The following record type has not been implemented: {recordType}");
                    }
                }
            }

            TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;

            System.Console.WriteLine(@"Measured Time: " + (end - start).TotalMilliseconds + @"ms.");

            System.Console.ReadLine();
        }
    }
}
