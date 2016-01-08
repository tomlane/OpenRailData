using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class SeatingClassParser : ISeatingClassParser
    {
        public SeatingClass ParseSeatingClass(string seatingClass)
        {
            if (seatingClass == null)
                throw new ArgumentNullException(nameof(seatingClass));

            if (seatingClass == string.Empty)
                return SeatingClass.FirstAndStandardClass;
            
            switch (seatingClass)
            {
                case "S":
                    return SeatingClass.StandardClassOnly;
                case "B":
                case "":
                    return SeatingClass.FirstAndStandardClass;
                default:
                    throw new ArgumentException($"Unknown Seating Class: {seatingClass}");
            }
        }
    }
}