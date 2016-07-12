using System;
using System.Text;
using OpenRailData.Darwin.DataDecompression;
using OpenRailData.Darwin.DataFetching;
using OpenRailData.Darwin.ReferenceData;
using OpenRailData.Domain.DarwinReferenceData;

namespace OpenRailData.Darwin
{
    public interface IDarwinReferenceDataProvider
    {
        DarwinReferenceDataSet GetDataSet();
    }

    public class DarwinReferenceDataProvider : IDarwinReferenceDataProvider
    {
        private readonly IDarwinDataFileFetcher _dataFileFetcher;
        private readonly IDarwinReferenceDataParser _referenceDataParser;
        private readonly IDataDecompressor _dataDecompressor;

        public DarwinReferenceDataProvider(IDarwinDataFileFetcher dataFileFetcher, IDarwinReferenceDataParser referenceDataParser, IDataDecompressor dataDecompressor)
        {
            if (dataFileFetcher == null)
                throw new ArgumentNullException(nameof(dataFileFetcher));
            if (referenceDataParser == null)
                throw new ArgumentNullException(nameof(referenceDataParser));
            if (dataDecompressor == null)
                throw new ArgumentNullException(nameof(dataDecompressor));

            _dataFileFetcher = dataFileFetcher;
            _referenceDataParser = referenceDataParser;
            _dataDecompressor = dataDecompressor;
        }

        public DarwinReferenceDataSet GetDataSet()
        {
            var compressedDataFile = _dataFileFetcher.FetchFile(@"C:\Users\Tom\OneDrive\RailData\Darwin Reference Data\20160712020834_ref_v3.xml.gz");

            var dataFile = _dataDecompressor.Decompress(compressedDataFile);

            return _referenceDataParser.ParDarwinReferenceDataSet(Encoding.UTF8.GetString(dataFile));
        }
    }
}