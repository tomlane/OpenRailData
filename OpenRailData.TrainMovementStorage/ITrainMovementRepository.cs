﻿using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementRepository<T> where T : ITrainMovementMessage
    {
        void InsertRecord(T record);
        void AmendRecord(T record);
        void DeleteRecord(T record);

        Task InsertRecordAsync(T record);
        Task AmendRecordAsync(T record);
        Task DeleteRecordAsync(T record);
    }
}