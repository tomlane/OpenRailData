namespace NetworkRail.CifParser.Entities
{
    public enum CifRecordType
    {
        Header = 0,
        TiplocInsert = 1,
        TiplocAmend = 2,
        TiplocAmendOther = 3,
        TiplocDelete = 4,
        Association = 5,
        BasicSchedule = 6,
        Location = 7,
        ChangesEnRoute = 8
    }
}