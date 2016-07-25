using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule
{
    public interface IAssociationProvider
    {
        Task<AssociationRecord> GetAssociationByMainTrainUid(string mainTrainId, string location);
        Task<AssociationRecord> GetAssociationByAssocTrainUid(string assocTrainId, string location);
    }
}