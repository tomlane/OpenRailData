using System.Collections.Generic;

namespace OpenRailData.Darwin.Entites.ReferenceData
{
    public class DarwinReferenceDataSet
    {
        public List<DarwinCisSource> CisSources { get; set; }
        public List<DarwinLocationReference> LocationData { get; set; }
        public List<DarwinLateRunningReason> LateRunningReasons { get; set; }
        public List<DarwinCancellationReason> CancellationReasons { get; set; }
        public List<DarwinTocReference> TocData { get; set; }
        public List<DarwinViaRecord> ViaData { get; set; }
    }
}