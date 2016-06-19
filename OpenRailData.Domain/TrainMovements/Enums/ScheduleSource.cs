using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements.Enums
{
    public enum ScheduleSource
    {
        /// <summary>
        /// Cif.
        /// </summary>
        [Display(Name = "CIF")]
        C,
        /// <summary>
        /// VSTP: Very short Term Plan.
        /// </summary>
        [Display(Name = "Very Short Term Plan")]
        V
    }
}