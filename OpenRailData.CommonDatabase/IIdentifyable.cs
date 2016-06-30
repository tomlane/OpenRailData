using System;

namespace OpenRailData.CommonDatabase
{
    public interface IIdentifyable
    {
        Guid? Id { get; set; }
    }
}