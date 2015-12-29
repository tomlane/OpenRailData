using System;

namespace NetworkRail.CifParser.Entities
{
    public class BasicScheduleRecord : ICifRecord
    {
        public string TransactionType { get;  }
        public string Uid { get;  }
        public string UniqueId { get;  }
        public string DateFrom { get;  }
        public string DateTo { get;  }
        public string RunsMonday { get;  }
        public string RunsTuesday { get;  }
        public string RunsWednesday { get;  }
        public string RunsThursday { get;  }
        public string RunsFriday { get;  }
        public string RunsSaturday { get;  }
        public string RunsSunday { get;  }
        public string BankHoliday { get;  }
        public string Status { get;  }
        public string Category { get;  }
        public string TrainIdentity { get;  }
        public string HeadCode { get;  }
        public string ServiceCode { get;  }
        public string PortionId { get;  }
        public string PowerType { get;  }
        public string TimingLoad { get;  }
        public string Speed { get;  }
        public string OperatingCharacteristicsString { get;  }
        public string TrainClass { get;  }
        public string Sleepers { get;  }
        public string Reservations { get;  }
        public string CateringCode { get;  }
        public string ServiceBranding { get;  }
        public string StpIndicator { get;  }
        
        public bool Train { get;  }
        public bool Bus { get;  }
        public bool Ship { get;  }
        public bool Passenger { get;  }

        public string UicCode { get; set; }
        public string AtocCode { get; set; }
        public string AtsCode { get; set; }
        public string Rsid { get; set; }
        public string DataSource { get; set; }

        public OperatingCharacteristics OperatingCharacteristics { get;  }

        public BasicScheduleRecord(string record)
        {
            TransactionType = record.Substring(2, 1);

            try
            {
                Uid = record.Substring(3, 6);

                DateFrom = record.Substring(9, 6);
                DateTo = record.Substring(15, 6);

                RunsMonday = record.Substring(21, 1);
                RunsTuesday = record.Substring(22, 1);
                RunsWednesday = record.Substring(23, 1);
                RunsThursday = record.Substring(24, 1);
                RunsFriday = record.Substring(25, 1);
                RunsSaturday = record.Substring(26, 1);
                RunsSunday = record.Substring(27, 1);

                BankHoliday = record.Substring(28, 1);
                Status = record.Substring(29, 1);
                Category = record.Substring(30, 2);
                TrainIdentity = record.Substring(32, 4);
                HeadCode = record.Substring(36, 4);
                ServiceCode = record.Substring(41, 8);
                PortionId = record.Substring(49, 1);
                PowerType = record.Substring(50, 3);
                TimingLoad = record.Substring(53, 4);
                Speed = record.Substring(57, 3);

                OperatingCharacteristicsString = record.Substring(60, 6);
                TrainClass = record.Substring(66, 1);
                Sleepers = record.Substring(67, 1);
                Reservations = record.Substring(68, 1);
                CateringCode = record.Substring(70, 4);
                ServiceBranding = record.Substring(74, 4);
                StpIndicator = record.Substring(79, 1);
            }
            catch (ArgumentOutOfRangeException){}

            if (StpIndicator == "C" || TransactionType == "D")
            {
                if (RunsMonday == "0" || RunsMonday == " ")
                    RunsMonday = RunsMonday.Trim();

                if (RunsTuesday == "0" || RunsTuesday == " ")
                    RunsTuesday = RunsTuesday.Trim();

                if (RunsWednesday == "0" || RunsWednesday == " ")
                    RunsWednesday = RunsWednesday.Trim();

                if (RunsThursday == "0" || RunsThursday == " ")
                    RunsThursday = RunsThursday.Trim();

                if (RunsFriday == "0" || RunsFriday == " ")
                    RunsFriday = RunsFriday.Trim();

                if (RunsSaturday == "0" || RunsSaturday == " ")
                    RunsSaturday = RunsSaturday.Trim();

                if (RunsSunday == "0" || RunsSunday == " ")
                    RunsSunday = RunsSunday.Trim();
            }

            BankHoliday = BankHoliday.Trim();
            Category = Category.Trim();
            HeadCode = HeadCode.Trim();
            PortionId = PortionId.Trim();
            Sleepers = Sleepers.Trim();
            Reservations = Reservations.Trim();
            CateringCode = CateringCode.Trim();
            ServiceBranding = ServiceBranding.Trim();
            StpIndicator = StpIndicator.Trim();

            UniqueId = Uid + record.Substring(9, 6) + StpIndicator;

            Bus = false;
            Train = true;
            Ship = false;
            Passenger = false;

            if (Category == "BR" || Category == "BS")
            {
                Bus = true;
                Train = false;
            }
            else if (Status == "S" || Status == "4")
            {
                Ship = true;
                Train = false;
            }

            if (Bus || Ship || Category == "OL" || Category == "OO" || Category == "XC" || Category == "XX" || Category == "XZ")
                Passenger = true;

            OperatingCharacteristics = new OperatingCharacteristics(OperatingCharacteristicsString);

            OperatingCharacteristicsString = OperatingCharacteristicsString.Trim();
        }

        public void MergeExtraScheduleDetails(string record)
        {
            if (record.Substring(0, 2) != "BX")
                throw new ArgumentException("Merge record is not of type Schedule Extra Details.");

            UicCode = record.Substring(6, 5);
            AtocCode = record.Substring(11, 2);
            AtsCode = record.Substring(13, 1);
            Rsid = record.Substring(14, 8);
            DataSource = record.Substring(22, 1);

            UicCode = UicCode.Trim();
            AtocCode = AtocCode.Trim();
            AtsCode = AtsCode.Trim();
            Rsid = Rsid.Trim();
            DataSource = DataSource.Trim();
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.BasicSchedule;
        }
    }
}