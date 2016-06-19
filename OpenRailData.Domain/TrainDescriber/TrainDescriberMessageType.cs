using System.ComponentModel.DataAnnotations;

namespace OpenRailData.Domain.TrainDescriber
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