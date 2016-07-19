using System.ComponentModel.DataAnnotations;

namespace OpenRailData.TrainDescriber.Entities
{
    public enum TrainDescriberMessageType   
    {
        /// <summary>
        /// Berth message.
        /// </summary>
        [Display(Name = "Berth Message")]
        BerthMessage,
        /// <summary>
        /// Signal message.
        /// </summary>
        [Display(Name = "Signal Message")]
        SignalMessage
    }
}