namespace NetworkRail.CifParser.Records
{
    public enum CifRecordType
    {
        Header = 1,
        TiplocInsert = 2,
        TiplocAmend = 3,
        TiplocDelete = 4,
        Association = 5,
        BasicSchedule = 6,
        BasicScheduleExtraDetails = 7,
        OriginLocation = 8,
        IntermediateLocation = 9,
        TerminatingLocation = 10,
        ChangesEnRoute = 11,
        EndOfFile = 12
    }
}