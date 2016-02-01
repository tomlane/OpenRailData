using System.ComponentModel;

namespace NetworkRail.CifParser.Records.Enums
{
    public enum PowerType
    {
        [Description("Diesel")]
        D = 1,

        [Description("Diesel Electric Multiple Unit")]
        DEM = 2,

        [Description("Diesel Mechanical Multiple Unit")]
        DMU = 3,

        [Description("Electric")]
        E = 4,

        [Description("Electro-Diesel")]
        ED = 5,

        [Description("Electric Multiple Unit plus Diesel, Electric, or Electro-Diesel locomotive")]
        EML = 6,

        [Description("Electric Multiple Unit")]
        EMU = 7,

        [Description("Electric Parcels Unit")]
        EPU = 8,

        [Description("High Speed Train")]
        HST = 9,

        [Description("Diesel Shunting Lococmotive")]
        LDS = 10,

        [Description("None defined")]
        None = 11
    }
}