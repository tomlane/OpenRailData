using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Api.BindingModels
{
    public class ScheduleLocationSearchBindingModel
    {
        [Required]
        public string Tiploc { get; set; }
    }
}