using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Entities
{
    public enum ScheduleRecordType
    {
        /// <summary>
        /// Header record.
        /// </summary>
        [Display(Name = "Header Record")]
        HD = 1,
        /// <summary>
        /// Tiploc insert record.
        /// </summary>
        [Display(Name = "Tiploc Insert Record")]
        TI = 2,
        /// <summary>
        /// Tiploc amend record.
        /// </summary>
        [Display(Name = "Tiploc Amend Record")]
        TA = 4,
        /// <summary>
        /// Tiploc delete record.
        /// </summary>
        [Display(Name = "Tiploc Delete Record")]
        TD = 5,
        /// <summary>
        /// Association insert record.
        /// </summary>
        [Display(Name = "Association Insert Record")]
        AAN = 6,
        /// <summary>
        /// Association amend record.
        /// </summary>
        [Display(Name = "Association Amend Record")]
        AAR = 7,
        /// <summary>
        /// Association delete record.
        /// </summary>
        [Display(Name = "Association Delete Record")]
        AAD = 8,
        /// <summary>
        /// Basic schedule insert record.
        /// </summary>
        [Display(Name = "Basic Schedule Insert Record")]
        BSN = 9,
        /// <summary>
        /// Basic schedule amend record.
        /// </summary>
        [Display(Name = "Basic Schedule Amend Record")]
        BSR = 10,
        /// <summary>
        /// Basic schedule delete record.
        /// </summary>
        [Display(Name = "Basic Schedule Delete Record")]
        BSD = 11,
        /// <summary>
        /// Basic schedule extra details record.
        /// </summary>
        [Display(Name = "Basic Schedule Extra Details Record")]
        BX = 12,
        /// <summary>
        /// Origin location record.
        /// </summary>
        [Display(Name = "Origin Location Record")]
        LO = 13,
        /// <summary>
        /// Intermediate location record.
        /// </summary>
        [Display(Name = "Intermediate Location Record")]
        LI = 14,
        /// <summary>
        /// Changes en route record.
        /// </summary>
        [Display(Name = "Changes en Route Record")]
        CR = 15,
        /// <summary>
        /// Terminating location record.
        /// </summary>
        [Display(Name = "Terminating Location Record")]
        LT = 16,
        /// <summary>
        /// End of file record.
        /// </summary>
        [Display(Name = "End of File Record")]
        ZZ = 17
    }
}