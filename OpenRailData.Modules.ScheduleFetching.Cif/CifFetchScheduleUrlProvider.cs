using System;
using System.Collections.Generic;
using OpenRailData.ScheduleFetching;

namespace OpenRailData.Modules.ScheduleFetching.Cif
{
    public class CifFetchScheduleUrlProvider : IFetchScheduleUrlProvider
    {
        private Dictionary<DayOfWeek, string> _dailyUrlDictionary;

        public CifFetchScheduleUrlProvider()
        {
            BuildDailyDictionary();
        }

        public string GetWeeklyScheduleUrl()
        {
            return "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_FULL_DAILY&day=toc-full.CIF.gz";
        }

        public string GetDailyUpdateScheduleUrl()
        {
            return _dailyUrlDictionary[DateTime.Now.DayOfWeek];
        }

        private void BuildDailyDictionary()
        {
            _dailyUrlDictionary = new Dictionary<DayOfWeek, string>
            {
                {
                    DayOfWeek.Monday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-sun.CIF.gz"
                },
                {
                    DayOfWeek.Tuesday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-mon.CIF.gz"
                },
                {
                    DayOfWeek.Wednesday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-tue.CIF.gz"
                },
                {
                    DayOfWeek.Thursday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-wed.CIF.gz"
                },
                {
                    DayOfWeek.Friday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-thu.CIF.gz"
                },
                {
                    DayOfWeek.Saturday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-fri.CIF.gz"
                },
                {
                    DayOfWeek.Sunday,
                    "https://datafeeds.networkrail.co.uk/ntrod/CifFileAuthenticate?type=CIF_ALL_UPDATE_DAILY&day=toc-update-sat.CIF.gz"
                }
            };

        }
    }
}