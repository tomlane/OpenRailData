using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum AssociationType
    {
        [Description("None")]
        None = 0,

        [Description("Passenger Use")]
        PassengerUse = 1,

        [Description("Operating Use Only")]
        OperatingUseOnly = 2
    }
}