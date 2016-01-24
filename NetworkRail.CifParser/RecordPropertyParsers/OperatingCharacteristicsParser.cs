using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class OperatingCharacteristicsParser : IOperatingCharacteristicsParser
    {
        public OperatingCharacteristics ParseOperatingCharacteristics(string characteristics)
        {
            if (characteristics == null)
                throw new ArgumentNullException(nameof(characteristics));

            OperatingCharacteristics operatingCharacteristics = new OperatingCharacteristics();

            foreach (var oc in characteristics)
            {
                if (oc == 'B')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.B;
                else if (oc == 'C')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.C;
                else if (oc == 'D')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.D;
                else if (oc == 'E')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.E;
                else if (oc == 'G')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.G;
                else if (oc == 'M')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.M;
                else if (oc == 'P')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.P;
                else if (oc == 'Q')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.Q;
                else if (oc == 'R')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.R;
                else if (oc == 'S')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.S;
                else if (oc == 'Y')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.Y;
                else if (oc == 'Z')
                    operatingCharacteristics = operatingCharacteristics | OperatingCharacteristics.Z;
            }

            return operatingCharacteristics;
        }
    }
}