using System;
using System.Collections.Generic;
using System.Linq;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordParsers
{
    public class TerminatingLocationRecordParser : ICifRecordParser
    {
        private readonly Dictionary<string, IRecordEnumPropertyParser> _enumPropertyParsers; 

        public TerminatingLocationRecordParser(IRecordEnumPropertyParser[] enumPropertyParsers)
        {
            if (enumPropertyParsers == null)
                throw new ArgumentNullException(nameof(enumPropertyParsers));

            _enumPropertyParsers = enumPropertyParsers.ToDictionary(x => x.PropertyKey, x => x);
        }

        public string RecordKey { get; } = "LT";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new TerminatingLocationRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                WorkingArrival = recordString.Substring(10, 5).Trim(),
                PublicArrival = recordString.Substring(15, 4).Trim(),
                Platform = recordString.Substring(19, 3).Trim(),
                Path = recordString.Substring(22, 3).Trim(),
                LocationActivityString = recordString.Substring(25, 12),
            };

            record.LocationActivity = (LocationActivity)_enumPropertyParsers["LocationActivity"].ParseProperty(record.LocationActivityString);

            record.OrderTime = record.WorkingArrival;

            return record;
        }
    }
}