using System.ComponentModel;

namespace OpenRailData.Domain.ScheduleRecords
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

        [Description("Basic Schedule Insert Record")]
        BSN = 9,

        [Description("Basic Schedule Amend Record")]
        BSR = 10,

        [Description("Basic Schedule Delete Record")]
        BSD = 11,

        [Description("Basic Schedule Extra Details Record")]
        BX = 12,

        [Description("Origin Location Record")]
        LO = 13,

        [Description("Intermediate Location Record")]
        LI = 14,

        [Description("Changes en Route Record")]
        CR = 15,

        [Description("Terminating Location Record")]
        LT = 16,
        
        [Description("End of File Record")]
        ZZ = 17
    }
}