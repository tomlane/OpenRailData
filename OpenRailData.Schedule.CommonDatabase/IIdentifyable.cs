using System;

namespace OpenRailData.Schedule.CommonDatabase
{
    public interface IIdentifyable
    {
        Guid? Id { get; set; }
    }
}