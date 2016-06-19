using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.ScheduleRecords.Enums
{
    public enum PowerType
    {
        /// <summary>
        /// Diesel.
        /// </summary>
        [Display(Name = "Diesel")]
        D = 1,
        /// <summary>
        /// Diesel electric multiple unit.
        /// </summary>
        [Display(Name = "Diesel Electric Multiple Unit")]
        DEM = 2,
        /// <summary>
        /// Diesel mechanical multiple unit.
        /// </summary>
        [Display(Name = "Diesel Mechanical Multiple Unit")]
        DMU = 3,
        /// <summary>
        /// Electric.
        /// </summary>
        [Display(Name = "Electric")]
        E = 4,
        /// <summary>
        /// Electro-Diesel.
        /// </summary>
        [Display(Name = "Electro-Diesel")]
        ED = 5,
        /// <summary>
        /// Electric multiple unit plus diesel, electric, or electro-diesel locomotive.
        /// </summary>
        [Display(Name = "Electric Multiple Unit plus Diesel, Electric, or Electro-Diesel locomotive")]
        EML = 6,
        /// <summary>
        /// Electric multiple unit.
        /// </summary>
        [Display(Name = "Electric Multiple Unit")]
        EMU = 7,
        /// <summary>
        /// Electric parcels unit.
        /// </summary>
        [Display(Name = "Electric Parcels Unit")]
        EPU = 8,
        /// <summary>
        /// High speed train.
        /// </summary>
        [Display(Name = "High Speed Train")]
        HST = 9,
        /// <summary>
        /// Diesel shunting locomotive.
        /// </summary>
        [Display(Name = "Diesel Shunting Locomotive")]
        LDS = 10,
        /// <summary>
        /// None defined. 
        /// </summary>
        [Display(Name = "None defined")]
        None = 11
    }
}