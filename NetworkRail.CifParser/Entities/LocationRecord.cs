namespace NetworkRail.CifParser.Entities
{
    public class LocationRecord : ICifRecord
    {
        public string RecordType { get; }
        public string Tiploc { get; }
        public string TiplocInstance { get; }
        public string Arrival { get; } = string.Empty;
        public string PublicArrival { get; } = string.Empty;
        public string Departure { get; } = string.Empty;
        public string PublicDeparture { get; } = string.Empty;
        public string Pass { get; } = string.Empty;
        public string Platform { get; } = string.Empty;
        public string Line { get; } = string.Empty;
        public string Path { get; } = string.Empty;
        public string EngineeringAllowance { get; } = string.Empty;
        public string PathingAllowance { get; } = string.Empty;
        public string PerformanceAllowance { get; } = string.Empty;

        public string ActivityString { get; } = string.Empty;
        public LocationActivity Activity { get; }

        public string OrderTime { get; set; }

        public bool PublicCall { get; set; }
        public bool ActualCall { get; set; }

        public LocationRecord(string record)
        {
            RecordType = record.Substring(0, 2);
            Tiploc = record.Substring(2, 7);
            TiplocInstance = record.Substring(9, 1);

            if (RecordType == "LO")
            {
                Departure = record.Substring(10, 5);
                PublicDeparture = record.Substring(15, 4);
                Platform = record.Substring(19, 3);
                Line = record.Substring(22, 3);
                EngineeringAllowance = record.Substring(25, 2);
                PathingAllowance = record.Substring(27, 2);
                ActivityString = record.Substring(29, 12);
                PerformanceAllowance = record.Substring(41, 2);
            }
            else if (RecordType == "LI")
            {
                Arrival = record.Substring(10, 5);
                Departure = record.Substring(15, 5);
                Pass = record.Substring(20, 5);
                PublicArrival = record.Substring(25, 4);
                PublicDeparture = record.Substring(29, 4);
                Platform = record.Substring(33, 3);
                Line = record.Substring(36, 3);
                Path = record.Substring(39, 3);
                ActivityString = record.Substring(42, 12);
                EngineeringAllowance = record.Substring(54, 2);
                PathingAllowance = record.Substring(56, 2);
                PerformanceAllowance = record.Substring(58, 2);
            }
            else if (RecordType == "LT")
            {
                Arrival = record.Substring(10, 5);
                PublicArrival = record.Substring(15, 4);
                Platform = record.Substring(19, 3);
                Path = record.Substring(22, 3);
                ActivityString = record.Substring(25, 12);
            }

            Tiploc = Tiploc.Trim();
            TiplocInstance = TiplocInstance.Trim();

            Arrival = Arrival.Trim();
            Departure = Departure.Trim();
            Pass = Pass.Trim();
            PublicArrival = PublicArrival.Trim();
            PublicDeparture = PublicDeparture.Trim();

            Platform = Platform.Trim();
            Line = Line.Trim();
            Path = Path.Trim();
            EngineeringAllowance = EngineeringAllowance.Trim();
            PathingAllowance = PathingAllowance.Trim();
            PerformanceAllowance = PerformanceAllowance.Trim();

            if (PublicArrival == "0000")
                PublicArrival = string.Empty;

            if (PublicDeparture == "0000")
                PublicDeparture = string.Empty;

            Activity = new LocationActivity(ActivityString);
            ActivityString = ActivityString.Trim();

            PublicCall = Activity.N && (PublicArrival != string.Empty || PublicDeparture != string.Empty);
            ActualCall = Arrival != string.Empty || Departure != string.Empty;

            if (Pass != string.Empty)
                OrderTime = Pass;
            else if (Departure != string.Empty)
                OrderTime = Departure;
            else
                OrderTime = Arrival;
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Location;
        }
    }
}