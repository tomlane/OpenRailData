﻿namespace OpenRailData.Darwin.Entites.ReferenceData
{
    public class DarwinLocationReference
    {
        public string TiplocCode { get; set; }
        public string CrsCode { get; set; }
        public string Toc { get; set; }
        public string LocationName { get; set; }

        public override string ToString()
        {
            return $"{nameof(TiplocCode)}: {TiplocCode}, {nameof(CrsCode)}: {CrsCode}, {nameof(Toc)}: {Toc}, {nameof(LocationName)}: {LocationName}";
        }
    }
}