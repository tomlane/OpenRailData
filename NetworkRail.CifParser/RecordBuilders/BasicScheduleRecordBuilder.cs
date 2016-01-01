using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records;

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
            BasicScheduleRecord record = new BasicScheduleRecord
            {
                TransactionType = recordString.Substring(2, 1)
            };

            try
            {
                record.Uid = recordString.Substring(3, 6);

                record.DateFrom = recordString.Substring(9, 6);
                record.DateTo = recordString.Substring(15, 6);

                record.RunsMonday = recordString.Substring(21, 1);
                record.RunsTuesday = recordString.Substring(22, 1);
                record.RunsWednesday = recordString.Substring(23, 1);
                record.RunsThursday = recordString.Substring(24, 1);
                record.RunsFriday = recordString.Substring(25, 1);
                record.RunsSaturday = recordString.Substring(26, 1);
                record.RunsSunday = recordString.Substring(27, 1);

                record.BankHoliday = recordString.Substring(28, 1);
                record.Status = recordString.Substring(29, 1);
                record.Category = recordString.Substring(30, 2);
                record.TrainIdentity = recordString.Substring(32, 4);
                record.HeadCode = recordString.Substring(36, 4);
                record.ServiceCode = recordString.Substring(41, 8);
                record.PortionId = recordString.Substring(49, 1);
                record.PowerType = recordString.Substring(50, 3);
                record.TimingLoad = recordString.Substring(53, 4);
                record.Speed = recordString.Substring(57, 3);

                record.OperatingCharacteristicsString = recordString.Substring(60, 6);
                record.TrainClass = recordString.Substring(66, 1);
                record.Sleepers = recordString.Substring(67, 1);
                record.Reservations = recordString.Substring(68, 1);
                record.CateringCode = recordString.Substring(70, 4);
                record.ServiceBranding = recordString.Substring(74, 4);
                record.StpIndicator = recordString.Substring(79, 1);
            }
            catch (ArgumentOutOfRangeException) { }

            if (record.StpIndicator == "C" || record.TransactionType == "D")
            {
                if (record.RunsMonday == "0" || record.RunsMonday == " ")
                    record.RunsMonday = record.RunsMonday.Trim();

                if (record.RunsTuesday == "0" || record.RunsTuesday == " ")
                    record.RunsTuesday = record.RunsTuesday.Trim();

                if (record.RunsWednesday == "0" || record.RunsWednesday == " ")
                    record.RunsWednesday = record.RunsWednesday.Trim();

                if (record.RunsThursday == "0" || record.RunsThursday == " ")
                    record.RunsThursday = record.RunsThursday.Trim();

                if (record.RunsFriday == "0" || record.RunsFriday == " ")
                    record.RunsFriday = record.RunsFriday.Trim();

                if (record.RunsSaturday == "0" || record.RunsSaturday == " ")
                    record.RunsSaturday = record.RunsSaturday.Trim();

                if (record.RunsSunday == "0" || record.RunsSunday == " ")
                    record.RunsSunday = record.RunsSunday.Trim();
            }

            record.BankHoliday = record.BankHoliday.Trim();
            record.Category = record.Category.Trim();
            record.HeadCode = record.HeadCode.Trim();
            record.PortionId = record.PortionId.Trim();
            record.Sleepers = record.Sleepers.Trim();
            record.Reservations = record.Reservations.Trim();
            record.CateringCode = record.CateringCode.Trim();
            record.ServiceBranding = record.ServiceBranding.Trim();
            record.StpIndicator = record.StpIndicator.Trim();

            record.UniqueId = record.Uid + recordString.Substring(9, 6) + record.StpIndicator;

            record.Bus = false;
            record.Train = true;
            record.Ship = false;
            record.Passenger = false;

            if (record.Category == "BR" || record.Category == "BS")
            {
                record.Bus = true;
                record.Train = false;
            }
            else if (record.Status == "S" || record.Status == "4")
            {
                record.Ship = true;
                record.Train = false;
            }

            if (record.Bus || record.Ship || record.Category == "OL" || record.Category == "OO" || record.Category == "XC" || record.Category == "XX" || record.Category == "XZ")
                record.Passenger = true;

            record.OperatingCharacteristics = _operatingCharacteristicsParser.ParseOperatingCharacteristics(record.OperatingCharacteristicsString);

            record.OperatingCharacteristicsString = record.OperatingCharacteristicsString.Trim();

            return record;
        }
    }
}