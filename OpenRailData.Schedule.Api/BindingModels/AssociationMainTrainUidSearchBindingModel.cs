using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Schedule.Api.BindingModels
{
    public class AssociationMainTrainUidSearchBindingModel
    {
        [Required]
        public string MainTrainUid { get; set; }
        [Required]
        public string Location { get; set; }
    }
}