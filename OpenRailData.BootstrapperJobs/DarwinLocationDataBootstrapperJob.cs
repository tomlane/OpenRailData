using System;
using System.Linq;
using System.Threading.Tasks;
using OpenRailData.Darwin;
using OpenRailData.Schedule;

namespace OpenRailData.BootstrapperJobs
{
    public class DarwinLocationDataBootstrapperJob : IDarwinLocationDataBootstrapperJob
    {
        private readonly IDarwinReferenceDataProvider _darwinReferenceDataProvider;
        private readonly ITiplocEditor _tiplocEditor;

        public DarwinLocationDataBootstrapperJob(IDarwinReferenceDataProvider darwinReferenceDataProvider, ITiplocEditor tiplocEditor)
        {
            if (darwinReferenceDataProvider == null)
                throw new ArgumentNullException(nameof(darwinReferenceDataProvider));
            if (tiplocEditor == null)
                throw new ArgumentNullException(nameof(tiplocEditor));

            _darwinReferenceDataProvider = darwinReferenceDataProvider;
            _tiplocEditor = tiplocEditor;
        }

        public void Execute()
        {
            var darwinData = _darwinReferenceDataProvider.GetDataSet();

            var requests = darwinData.LocationData.Select(location => new AmendTiplocLocationNameRequest
            {
                TiplocCode = location.TiplocCode,
                LocationName = location.LocationName
            }).ToList();

            Task.Run(() => _tiplocEditor.UpdateTiplocLocationName(requests)).Wait();
        }
    }
}