using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class BasicScheduleRecordBuilder : ICifRecordBuilder<BasicScheduleRecord>
    {
        private readonly IOperatingCharacteristicsParser _operatingCharacteristicsParser;

        public BasicScheduleRecordBuilder(IOperatingCharacteristicsParser operatingCharacteristicsParser)
        {
            if (operatingCharacteristicsParser == null)
                throw new ArgumentNullException(nameof(operatingCharacteristicsParser));

            _operatingCharacteristicsParser = operatingCharacteristicsParser;
        }

        public BasicScheduleRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            BasicScheduleRecord record = new BasicScheduleRecord
            {
                TransactionType = recordString.Substring(2, 1).Trim(),
                TrainUid = recordString.Substring(3, 6).Trim(),
                DateRunsFrom = recordString.Substring(9, 6).Trim(),
                DateRunsTo = recordString.Substring(15, 6).Trim(),
                BankHoliday = recordString.Substring(28, 1).Trim(),
                TrainStatus = recordString.Substring(29, 1).Trim(),
                TrainCategory = recordString.Substring(30, 2).Trim(),
                TrainIdentity = recordString.Substring(32, 4).Trim(),
                HeadCode = recordString.Substring(36, 4).Trim(),
                CourseIndicator = recordString.Substring(40, 1).Trim(),
                TrainServiceCode = recordString.Substring(41, 8).Trim(),
                PortionId = recordString.Substring(49, 1).Trim(),
                PowerType = recordString.Substring(50, 3).Trim(),
                TimingLoad = recordString.Substring(53, 4).Trim(),
                Speed = recordString.Substring(57, 3).Trim(),
                OperatingCharacteristicsString = recordString.Substring(60, 6),
                SeatingClass = recordString.Substring(66, 1).Trim(),
                Sleepers = recordString.Substring(67, 1).Trim(),
                Reservations = recordString.Substring(68, 1).Trim(),
                ConnectionIndicator = recordString.Substring(69, 1).Trim(),
                CateringCode = recordString.Substring(70, 4).Trim(),
                ServiceBranding = recordString.Substring(74, 4).Trim(),
                StpIndicator = recordString.Substring(79, 1).Trim()
            };

            if (recordString.Substring(21, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Monday;
            if (recordString.Substring(22, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Tuesday;
            if (recordString.Substring(23, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Wednesday;
            if (recordString.Substring(24, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Thursday;
            if (recordString.Substring(25, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Friday;
            if (recordString.Substring(26, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Saturday;
            if (recordString.Substring(27, 1).Trim() == "1")
                record.RunningDays = record.RunningDays | Days.Sunday;
            
            record.UniqueId = record.TrainUid + recordString.Substring(9, 6) + record.StpIndicator;

            if (record.TrainCategory == "BR" || record.TrainCategory == "BS")
            {
                record.Bus = true;
                record.Train = false;
            }
            else if (record.TrainStatus == "S" || record.TrainStatus == "4")
            {
                record.Ship = true;
                record.Train = false;
            }

            if (record.Bus || record.Ship || record.TrainCategory == "OL" || record.TrainCategory == "OO" || record.TrainCategory == "XC" || record.TrainCategory == "XX" || record.TrainCategory == "XZ")
                record.Passenger = true;

            record.OperatingCharacteristics = _operatingCharacteristicsParser.ParseOperatingCharacteristics(record.OperatingCharacteristicsString);
            
            return record;
        }
    }
}