﻿using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule
{
    public interface ITiplocProvider
    {
        Task<TiplocRecord> GetTiplocByCrs(string crs);
        Task<TiplocRecord> GetTiplocByStanox(string stanox);
        Task<string> GetLocationNameByStanox(string stanox);
        Task<string> GetLocationNameByTiplocCode(string tiplocCode);
    }
}