namespace NetworkRail.CifParser.Entities
{
    public class TiplocDeleteRecord : ICifRecord
    {
        public string TiplocCode { get;  }
        public string Nlc { get;  }
        public string TpsDescription { get;  }
        public string Stanox { get;  }
        public string Crs { get;  }
        public string CapriDescription { get;  }
        public string OldTiploc { get;  }

        public TiplocDeleteRecord(string record)
        {
            TiplocCode = record.Substring(2, 7);
            TiplocCode = TiplocCode.Trim();
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.TiplocDelete;
        }
    }
}