namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public enum ScheduleRecordType
    {
        CifHeader = 1,
        JsonHeader = 2,
        TiplocInsert = 3,
        TiplocAmend = 4,
        TiplocDelete = 5,
        Association = 6,
        Schedule = 7,
        BasicSchedule = 8,
        BasicScheduleExtraDetails = 9,
        OriginLocation = 10,
        IntermediateLocation = 11,
        TerminatingLocation = 12,
        ChangesEnRoute = 13,
        EndOfFile = 14
    }
}