namespace NetworkRail.CifParser.Records
{
    public enum ScheduleRecordType
    {
        CifHeader = 1,
        JsonHeader = 2,
        TiplocInsert = 3,
        TiplocAmend = 4,
        TiplocDelete = 5,
        Association = 6,
        BasicSchedule = 7,
        BasicScheduleExtraDetails = 8,
        OriginLocation = 9,
        IntermediateLocation = 10,
        TerminatingLocation = 11,
        ChangesEnRoute = 12,
        EndOfFile = 13
    }
}