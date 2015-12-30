namespace NetworkRail.CifParser.Entities
{
    public class ChangesEnRouteRecord : ICifRecord
    {
        public string Tiploc { get;  } 
        public string TiplocSuffix { get;  } 
        public string Category { get;  }
        public string TrainIdentity { get; } 
        public string HeadCode { get;  } 
        public string ServiceCode { get; }
        public string PortionId { get; } 
        public string PowerType { get;  }
        public string TimingLoad { get;  }
        public string Speed { get;  }
        public string OperatingCharacteristics { get;  }
        public string TrainClass { get;  }
        public string Sleepers { get;  }
        public string Reservations { get;  }
        public string CateringCode { get;  }
        public string ServiceBranding { get;  }
        public string UicCode { get;  }
        public string Rsid { get;  }

        public ChangesEnRouteRecord(string record)
        {
            Tiploc = record.Substring(2, 7);
            TiplocSuffix = record.Substring(9, 1);
            Category = record.Substring(10, 2);
            TrainIdentity = record.Substring(12, 4);
            HeadCode = record.Substring(16, 4);
            ServiceCode = record.Substring(21, 8);
            PortionId = record.Substring(29, 1);
            PowerType = record.Substring(30, 3);
            TimingLoad = record.Substring(33, 4);
            Speed = record.Substring(37, 3);
            OperatingCharacteristics = record.Substring(40, 6);
            TrainClass = record.Substring(46, 1);
            Sleepers = record.Substring(47, 1);
            Reservations = record.Substring(48, 1);
            CateringCode = record.Substring(50, 4);
            ServiceBranding = record.Substring(54, 4);
            UicCode = record.Substring(58, 5);
            Rsid = record.Substring(63, 8);
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.ChangesEnRoute;
        }
    }
}