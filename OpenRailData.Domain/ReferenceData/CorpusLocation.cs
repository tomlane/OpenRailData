namespace OpenRailData.Domain.ReferenceData
{
    public class CorpusLocation
    {
        /// <summary>
        ///     Stanox code.
        /// </summary>
        public string Stanox { get; set; }
        /// <summary>
        ///     UIC code.
        /// </summary>
        public string Uic { get; set; }
        /// <summary>
        ///     3-letter location code.
        /// </summary>
        public string ThreeAlpha { get; set; }
        /// <summary>
        ///     Tiploc code.
        /// </summary>
        public string Tiploc { get; set; }
        /// <summary>
        ///     NLC code.
        /// </summary>
        public string Nlc { get; set; }
        /// <summary>
        ///     Description of the NLC code.
        /// </summary>
        public string NlcDesc { get; set; }
        /// <summary>
        ///     Description of the NLC code (16-character version).
        /// </summary>
        public string NlcDescSixteen { get; set; } 
    }
}