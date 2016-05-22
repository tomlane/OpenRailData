using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum PowerType
    {
        [Display(Name = "Diesel")]
        D = 1,

        [Display(Name = "Diesel Electric Multiple Unit")]
        DEM = 2,

        [Display(Name = "Diesel Mechanical Multiple Unit")]
        DMU = 3,

        [Display(Name = "Electric")]
        E = 4,

        [Display(Name = "Electro-Diesel")]
        ED = 5,

        [Display(Name = "Electric Multiple Unit plus Diesel, Electric, or Electro-Diesel locomotive")]
        EML = 6,

        [Display(Name = "Electric Multiple Unit")]
        EMU = 7,

        [Display(Name = "Electric Parcels Unit")]
        EPU = 8,

        [Display(Name = "High Speed Train")]
        HST = 9,

        [Display(Name = "Diesel Shunting Lococmotive")]
        LDS = 10,

        [Display(Name = "None defined")]
        None = 11
    }
}