using System;
using System.Globalization;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordParsers
{
    public class BasicScheduleRecordParser : ICifRecordParser
    {
        private readonly IBasicScheduleRecordParserContainer _recordParserContainer;

        public BasicScheduleRecordParser(IBasicScheduleRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public string RecordKey { get; } = "BS";

        public ICifRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            BasicScheduleRecord record = new BasicScheduleRecord
            {
                TransactionType = _recordParserContainer.TransactionTypeParser.ParseTransactionType(recordString.Substring(2, 1)),
                TrainUid = recordString.Substring(3, 6),
                DateRunsTo = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yyMMdd",
                    DateTimeString = recordString.Substring(15, 6)
                }),
                RunningDays = _recordParserContainer.RunningDaysParser.ParseRunningDays(recordString.Substring(21, 7)),
                BankHolidayRunning = _recordParserContainer.BankHolidayRunningParser.ParseBankHolidayRunning(recordString.Substring(28, 1)),
                TrainStatus = recordString.Substring(29, 1).Trim(),
                TrainCategory = recordString.Substring(30, 2).Trim(),
                TrainIdentity = recordString.Substring(32, 4).Trim(),
                HeadCode = recordString.Substring(36, 4).Trim(),
                CourseIndicator = recordString.Substring(40, 1).Trim(),
                TrainServiceCode = recordString.Substring(41, 8).Trim(),
                PortionId = recordString.Substring(49, 1).Trim(),
                PowerType = recordString.Substring(50, 3).Trim(),
                TimingLoad = recordString.Substring(53, 4).Trim(),
                OperatingCharacteristicsString = recordString.Substring(60, 6),
                SeatingClass = _recordParserContainer.SeatingClassParser.ParseSeatingClass(recordString.Substring(66, 1)),
                Sleepers = _recordParserContainer.SleeperDetailsParser.ParseTrainSleeperDetails(recordString.Substring(67, 1)),
                Reservations = _recordParserContainer.ReservationDetailsParser.ParseTrainResevationDetails(recordString.Substring(68, 1)),
                ConnectionIndicator = recordString.Substring(69, 1).Trim(),
                CateringCode = recordString.Substring(70, 4).Trim(),
                ServiceBranding = recordString.Substring(74, 4).Trim(),
                StpIndicator = _recordParserContainer.StpIndicatorParser.ParseStpIndicator(recordString.Substring(79, 1))
            };

            int speed;
            bool speedParsed = int.TryParse(recordString.Substring(57, 3).Trim(), NumberStyles.Any,
                new CultureInfo("en-gb"), out speed);

            if (speedParsed)
                record.Speed = speed;

            var dateRunsFromResult = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = recordString.Substring(9, 6)
            });

            if (dateRunsFromResult.HasValue)
                record.DateRunsFrom = dateRunsFromResult.Value;
            else
            {
                throw new ArgumentException("Failed to parse Date Runs From in Basic Schedule Record");
            }

            record.UniqueId = record.TrainUid + recordString.Substring(9, 6) + record.StpIndicator;

            if (record.TrainCategory == "BR" || record.TrainCategory == "BS")
            {
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Bus;
                record.ServiceTypeFlags = record.ServiceTypeFlags &= ~ServiceTypeFlags.Train;
            }
            else if (record.TrainStatus == "S" || record.TrainStatus == "4")
            {
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Ship;
                record.ServiceTypeFlags = record.ServiceTypeFlags &= ~ServiceTypeFlags.Train;
            }

            if (record.ServiceTypeFlags.HasFlag(ServiceTypeFlags.Bus) || record.ServiceTypeFlags.HasFlag(ServiceTypeFlags.Ship) || 
                record.TrainCategory == "OL" || record.TrainCategory == "OO" || record.TrainCategory == "XC" || record.TrainCategory == "XX" || record.TrainCategory == "XZ")
                record.ServiceTypeFlags = record.ServiceTypeFlags | ServiceTypeFlags.Passenger;

            record.OperatingCharacteristics = _recordParserContainer.OperatingCharacteristicsParser.ParseOperatingCharacteristics(record.OperatingCharacteristicsString);

            return record;
        }
    }
}