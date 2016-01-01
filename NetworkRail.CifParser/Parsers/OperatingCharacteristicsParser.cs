using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.Parsers
{
    public class OperatingCharacteristicsParser : IOperatingCharacteristicsParser
    {
        public OperatingCharacteristics ParseOperatingCharacteristics(string characteristics)
        {
            OperatingCharacteristics operatingCharacteristics = new OperatingCharacteristics();

            foreach (var oc in characteristics)
            {
                if (oc == 'B')
                    operatingCharacteristics.B = true;
                else if (oc == 'C')
                    operatingCharacteristics.C = true;
                else if (oc == 'D')
                    operatingCharacteristics.D = true;
                else if (oc == 'E')
                    operatingCharacteristics.E = true;
                else if (oc == 'G')
                    operatingCharacteristics.G = true;
                else if (oc == 'M')
                    operatingCharacteristics.M = true;
                else if (oc == 'P')
                    operatingCharacteristics.P = true;
                else if (oc == 'Q')
                    operatingCharacteristics.Q = true;
                else if (oc == 'R')
                    operatingCharacteristics.R = true;
                else if (oc == 'S')
                    operatingCharacteristics.S = true;
                else if (oc == 'Y')
                    operatingCharacteristics.Y = true;
                else if (oc == 'Z')
                    operatingCharacteristics.Z = true;
            }

            return operatingCharacteristics;
        }
    }
}