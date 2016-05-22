using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords
{
    public enum ScheduleRecordType
    {
        [Display(Name = "Header Record")]
        HD = 1,

        [Display(Name = "Tiploc Insert Record")]
        TI = 2,

        [Display(Name = "Tiploc Amend Record")]
        TA = 4,

        [Display(Name = "Tiploc Delete Record")]
        TD = 5,

        [Display(Name = "Association Insert Record")]
        AAN = 6,

        [Display(Name = "Association Amend Record")]
        AAR = 7,

        [Display(Name = "Association Delete Record")]
        AAD = 8,

        [Display(Name = "Basic Schedule Insert Record")]
        BSN = 9,

        [Display(Name = "Basic Schedule Amend Record")]
        BSR = 10,

        [Display(Name = "Basic Schedule Delete Record")]
        BSD = 11,

        [Display(Name = "Basic Schedule Extra Details Record")]
        BX = 12,

        [Display(Name = "Origin Location Record")]
        LO = 13,

        [Display(Name = "Intermediate Location Record")]
        LI = 14,

        [Display(Name = "Changes en Route Record")]
        CR = 15,

        [Display(Name = "Terminating Location Record")]
        LT = 16,
        
        [Display(Name = "End of File Record")]
        ZZ = 17
    }
}