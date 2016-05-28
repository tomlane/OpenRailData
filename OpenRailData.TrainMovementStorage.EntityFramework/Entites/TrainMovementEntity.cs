﻿using System;
using OpenRailData.Domain.TrainMovements.Enums;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Entites
{
    public class TrainMovementEntity : IIdentifyable
    {
        public Guid? Id { get; set; }

        public string SourceDeviceId { get; set; }
        public string SourceSystemId { get; set; }
        public string OriginalDataSource { get; set; }
        public string TrainId { get; set; }
        public DateTime EventTimestamp { get; set; }
        public string LocationStanox { get; set; }
        public DateTime PassengerTimestamp { get; set; }
        public DateTime PlannedTimestamp { get; set; }
        public string OriginalLocationStanox { get; set; }
        public DateTime? OriginalLocationTimestamp { get; set; }
        public EventType PlannedEventType { get; set; }
        public EventType EventType { get; set; }
        public EventSource EventSource { get; set; }
        public bool IsCorrection { get; set; }
        public bool IsOffRoute { get; set; }
        public Direction? Direction { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
        public string Route { get; set; }
        public string CurrentTrainId { get; set; }
        public string TrainServiceCode { get; set; }
        public string DivisionCode { get; set; }
        public string TocId { get; set; }
        public int TimetableVariation { get; set; }
        public VariationStatus VariationStatus { get; set; }
        public string NextReportStanox { get; set; }
        public int NextReportRunTime { get; set; }
        public bool HasTerminated { get; set; }
        public bool IsDelayMonitoringPoint { get; set; }
        public string TrainFileAddress { get; set; }
        public string ReportingStanox { get; set; }
        public bool IsAutoExpected { get; set; }
    }
}