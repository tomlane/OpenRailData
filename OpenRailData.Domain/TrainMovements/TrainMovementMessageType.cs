using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainMovements
{
    public enum TrainMovementMessageType
    {
        /// <summary>
        /// Train activation.
        /// </summary>
        [Display(Name = "Train Activation")]
        TrainActivation,
        /// <summary>
        /// Train cancellation.
        /// </summary>
        [Display(Name = "Train Cancellation")]
        TrainCancellation,
        /// <summary>
        /// Train movement.
        /// </summary>
        [Display(Name = "Train Movement")]
        TrainMovement,
        /// <summary>
        /// Train reinstatement.
        /// </summary>
        [Display(Name = "Train Reinstatement")]
        TrainReinstatement,
        /// <summary>
        /// Change of origin.
        /// </summary>
        [Display(Name = "Change Of Origin")]
        ChangeOfOrigin,
        /// <summary>
        /// Change of identity.
        /// </summary>
        [Display(Name = "Change Of Identity")]
        ChangeOfIdentity
    }
}