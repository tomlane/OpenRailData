using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OpenRailData.BerthStepData.Entites;

namespace OpenRailData.BerthStepData
{
    public class BerthStepDataProvider : IBerthStepDataProvider
    {
        public IList<BerthStep> GetBerthSteps()
        {
            throw new NotImplementedException();

            //var rawData = _dataFileDecompressor.DecompressDataFile(_dataFileFetcher.FetchDataFile(@"C:\RailData\BERTH Extracts\SMARTExtract.json.gz"));

            //var rawSteps = JsonConvert.DeserializeObject<RawBerthData>(Encoding.UTF8.GetString(rawData));

            //return rawSteps.RawBerthSteps.Select(rawBerthStep => new BerthStep
            //{
            //    BerthEvent = (BerthEvent) BerthEventParser.Parse(rawBerthStep.Event),
            //    BerthOffset = long.Parse(rawBerthStep.BerthOffset),
            //    BerthStepType = (BerthStepType) BerthStepTypeParser.Parse(rawBerthStep.StepType),
            //    Comment = rawBerthStep.Comment,
            //    FromBerth = rawBerthStep.FromBerth,
            //    FromLine = rawBerthStep.FromLine,
            //    Platform = rawBerthStep.Platform,
            //    Route = rawBerthStep.Route,
            //    Stanme = rawBerthStep.Stanme,
            //    Stanox = rawBerthStep.Stanox,
            //    ToBerth = rawBerthStep.ToBerth,
            //    ToLine = rawBerthStep.ToLine,
            //    TrainDescriber = rawBerthStep.TrainDescriber
            //}).ToList();
        }
    }

    internal class RawBerthData
    {
        [JsonProperty("BERTHDATA")]
        public List<RawBerthStep> RawBerthSteps { get; set; }
    }

    internal class RawBerthStep
    {
        [JsonProperty("TD")]
        public string TrainDescriber { get; set; }
        [JsonProperty("FROMBERTH")]
        public string FromBerth { get; set; }
        [JsonProperty("TOBERTH")]
        public string ToBerth { get; set; }
        [JsonProperty("FROMLINE")]
        public string FromLine { get; set; }
        [JsonProperty("TOLINE")]
        public string ToLine { get; set; }
        [JsonProperty("BERTHOFFSET")]
        public string BerthOffset { get; set; }
        [JsonProperty("PLATFORM")]
        public string Platform { get; set; }
        [JsonProperty("EVENT")]
        public string Event { get; set; }
        [JsonProperty("ROUTE")]
        public string Route { get; set; }
        [JsonProperty("STANOX")]
        public string Stanox { get; set; }
        [JsonProperty("STANME")]
        public string Stanme { get; set; }
        [JsonProperty("STEPTYPE")]
        public string StepType { get; set; }
        [JsonProperty("COMMENT")]
        public string Comment { get; set; }
    }
}