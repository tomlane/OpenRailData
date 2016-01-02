using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class ChangesEnRouteRecordBuilder : ICifRecordBuilder<ChangesEnRouteRecord>
    {
        public ChangesEnRouteRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            ChangesEnRouteRecord record = new ChangesEnRouteRecord
            {
                Tiploc = recordString.Substring(2, 7).Trim(),
                TiplocSuffix = recordString.Substring(9, 1).Trim(),
                Category = recordString.Substring(10, 2).Trim(),
                TrainIdentity = recordString.Substring(12, 4).Trim(),
                HeadCode = recordString.Substring(16, 4).Trim(),
                CourseIndicator = recordString.Substring(20, 1).Trim(),
                ServiceCode = recordString.Substring(21, 8).Trim(),
                PortionId = recordString.Substring(29, 1).Trim(),
                PowerType = recordString.Substring(30, 3).Trim(),
                TimingLoad = recordString.Substring(33, 4).Trim(),
                Speed = recordString.Substring(37, 3).Trim(),
                OperatingCharacteristics = recordString.Substring(40, 6).Trim(),
                SeatingClass = recordString.Substring(46, 1).Trim(),
                Sleepers = recordString.Substring(47, 1).Trim(),
                Reservations = recordString.Substring(48, 1).Trim(),
                ConnectionIndicator = recordString.Substring(49, 1).Trim(),
                CateringCode = recordString.Substring(50, 4).Trim(),
                ServiceBranding = recordString.Substring(54, 4).Trim(),
                UicCode = recordString.Substring(58, 5).Trim(),
                Rsid = recordString.Substring(63, 8).Trim()
            };

            return record;
        }
    }
}