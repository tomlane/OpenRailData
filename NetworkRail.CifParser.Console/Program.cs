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

            var cifRecordParser = new CifRecordParser();
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

            System.Console.WriteLine(@"Measured Time: " + (end - start).TotalMilliseconds + @"ms.");

            System.Console.ReadLine();
        }
    }
}
