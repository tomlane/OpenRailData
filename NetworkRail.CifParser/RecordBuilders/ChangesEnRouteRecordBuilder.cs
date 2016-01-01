using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class ChangesEnRouteRecordBuilder : ICifRecordBuilder<ChangesEnRouteRecord>
    {
        public ChangesEnRouteRecord BuildRecord(string recordString)
        {
            ChangesEnRouteRecord record = new ChangesEnRouteRecord
            {
                Tiploc = recordString.Substring(2, 7),
                TiplocSuffix = recordString.Substring(9, 1),
                Category = recordString.Substring(10, 2),
                TrainIdentity = recordString.Substring(12, 4),
                HeadCode = recordString.Substring(16, 4),
                ServiceCode = recordString.Substring(21, 8),
                PortionId = recordString.Substring(29, 1),
                PowerType = recordString.Substring(30, 3),
                TimingLoad = recordString.Substring(33, 4),
                Speed = recordString.Substring(37, 3),
                OperatingCharacteristics = recordString.Substring(40, 6),
                TrainClass = recordString.Substring(46, 1),
                Sleepers = recordString.Substring(47, 1),
                Reservations = recordString.Substring(48, 1),
                CateringCode = recordString.Substring(50, 4),
                ServiceBranding = recordString.Substring(54, 4),
                UicCode = recordString.Substring(58, 5),
                Rsid = recordString.Substring(63, 8)
            };

            return record;
        }
    }
}