using System.ComponentModel;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public enum ScheduleRecordType
    {
        [Description("Header Record")]
        HD = 1,

        [Description("Tiploc Insert Record")]
        TI = 2,

        [Description("Tiploc Amend Record")]
        TA = 4,

        [Description("Tiploc Delete Record")]
        TD = 5,

        [Description("Association Insert Record")]
        AAN = 6,

        [Description("Association Amend Record")]
        AAR = 7,

        [Description("Association Delete Record")]
        AAD = 8,

        Schedule = 9,

        [Description("Basic Schedule Insert Record")]
        BSN = 10,

        [Description("Basic Schedule Amend Record")]
        BSR = 11,

        [Description("Basic Schedule Delete Record")]
        BSD = 12,

        [Description("Basic Schedule Extra Details Record")]
        BX = 13,

        [Description("Origin Location Record")]
        LO = 14,

        [Description("Intermediate Location Record")]
        LI = 15,

        [Description("Changes en Route Record")]
        CR = 16,

        [Description("Terminating Location Record")]
        LT = 17,
        
        [Description("End of File Record")]
        ZZ = 18
    }
}