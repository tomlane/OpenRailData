﻿using System;
using OpenRailData.TrainMovement.Entities.Enums;

namespace OpenRailData.TrainMovement.Entities
{
    public class TrainActivation : ITrainMovementMessage
    {
        public TrainMovementMessageType MessageType { get; } = TrainMovementMessageType.TrainActivation;

        /// <summary>
        ///  Always blank for an activation message.
        /// </summary>
        public string SourceDeviceId { get; set; }
        /// <summary>
        /// 	"TRUST" for an activation message.
        /// </summary>
        public string SourceSystemId { get; set; }
        /// <summary>
        ///     "TSIA" for an activation message
        /// </summary>
        public string OriginalDataSource { get; set; }
        /// <summary>
        ///     The 10-character unique identity for this train.
        /// </summary>
        public string TrainId { get; set; }
        /// <summary>
        ///     The timestamp (in milliseconds since the UNIX epoch) when the train was originally created in TRUST.
        /// </summary>
        public DateTime EventTimestamp { get; set; }
        /// <summary>
        /// 	The date that the train runs. For trains activated before midnight that run after midnight, this date will be tomorrow's date.
        /// </summary>
        /// <remarks>There is currently a problem with this field due to the truncation of the timestamp. This only occurs during daylight savings for trains which start their journey between 0001 and 0200 the next day. To work around this problem, use the date in the <see cref="OriginDepartureTimestamp"/> field.</remarks>
        public DateTime OriginTimestamp { get; set; }
        /// <summary>
        /// 	The unique ID of the schedule being activated - either a letter and five numbers, or a space and five numbers for VSTP trains.
        /// </summary>
        public string TrainUid { get; set; }
        /// <summary>
        /// 	STANOX code for the originating location in the schedule.
        /// </summary>
        public string ScheduleOriginStanox { get; set; }
        /// <summary>
        ///     The start date of the schedule.
        /// </summary>
        public DateTime ScheduleStartDate { get; set; }
        /// <summary>
        ///     The end date of the schedule. 
        /// </summary>
        public DateTime ScheduleEndDate { get; set; }
        /// <summary>
        /// 	Set to C for schedules from CIF/ITPS, or V for schedules from VSTP/TOPS.
        /// </summary>
        public ScheduleSource ScheduleSource { get; set; }
        /// <summary>
        /// 	Either C (Cancellation), N (New STP), O (STP Overlay) or P (Permanent i.e. as per the WTT/LTP).
        /// </summary>
        /// <remarks>There is a issue that causes this field to be populated incorrectly. The value O should be P and P should be O.</remarks>
        public ScheduleType ScheduleType { get; set; }
        /// <summary>
        ///     The signaling ID (headcode) and speed class of the train.
        /// </summary>
        public string ScheduleWttId { get; set; }
        /// <summary>
        ///     Either 00000 for a CIF/ITPS schedule, or the TOPS unique ID of the schedule
        /// </summary>
        public string DRecordNumber { get; set; }
        /// <summary>
        /// 	The STANOX code of the origin of the train.
        /// </summary>
        /// <remarks>If the train is due to start from a location other than the scheduled origin (i.e. it is part-cancelled), this will be the STANOX of the location at which the train starts. Otherwise this field will be empty and you should refer to the 'sched_origin_stanox' field. If this field is populated, it will be typically be in response to a VAR issued through VSTP or SCHEDULE.</remarks>
        public string OriginStanox { get; set; }
        /// <summary>
        /// 	The WTT time of departure from the originating location. A UNIX timestamp in milliseconds since the UNIX epoch, in UTC.
        /// </summary>
        public DateTime OriginDepartureTimestamp { get; set; }
        /// <summary>
        /// 	Either AUTOMATIC for auto-called trains, or MANUAL for manual-called trains.
        /// </summary>
        public TrainCallType CallType { get; set; }
        /// <summary>
        ///     Set to NORMAL for a train called normally, or OVERNIGHT if the train is called as part of an overnight batch process to activate peak period trains early.
        /// </summary>
        public TrainCallMode CallMode { get; set; }
        /// <summary>
        /// 	Operating company ID as per TOC Codes.
        /// </summary>
        public string TocId { get; set; }
        /// <summary>
        ///     Train service code as per schedule.
        /// </summary>
        public string TrainServiceCode { get; set; }
        /// <summary>
        /// 	The TOPS train file address, if applicable.
        /// </summary>
        public string TrainFileAddress { get; set; }

        public override string ToString()
        {
            return $"CallMode: {CallMode}, CallType: {CallType}, DRecordNumber: {DRecordNumber}, EventTimestamp: {EventTimestamp}, OriginalDataSource: {OriginalDataSource}, OriginDepartureTimestamp: {OriginDepartureTimestamp}, OriginStanox: {OriginStanox}, OriginTimestamp: {OriginTimestamp}, ScheduleEndDate: {ScheduleEndDate}, ScheduleOriginStanox: {ScheduleOriginStanox}, ScheduleSource: {ScheduleSource}, ScheduleStartDate: {ScheduleStartDate}, ScheduleType: {ScheduleType}, ScheduleWttId: {ScheduleWttId}, SourceDeviceId: {SourceDeviceId}, SourceSystemId: {SourceSystemId}, TocId: {TocId}, TrainFileAddress: {TrainFileAddress}, TrainId: {TrainId}, TrainServiceCode: {TrainServiceCode}, TrainUid: {TrainUid}";
        }

        protected bool Equals(TrainActivation other)
        {
            return MessageType == other.MessageType && 
                string.Equals(SourceDeviceId, other.SourceDeviceId) && 
                string.Equals(SourceSystemId, other.SourceSystemId) && 
                string.Equals(OriginalDataSource, other.OriginalDataSource) && 
                string.Equals(TrainId, other.TrainId) && 
                EventTimestamp.Equals(other.EventTimestamp) && 
                OriginTimestamp.Equals(other.OriginTimestamp) && 
                string.Equals(TrainUid, other.TrainUid) && 
                string.Equals(ScheduleOriginStanox, other.ScheduleOriginStanox) && 
                ScheduleStartDate.Equals(other.ScheduleStartDate) && 
                ScheduleEndDate.Equals(other.ScheduleEndDate) && 
                ScheduleSource == other.ScheduleSource && 
                ScheduleType == other.ScheduleType && 
                string.Equals(ScheduleWttId, other.ScheduleWttId) && 
                string.Equals(DRecordNumber, other.DRecordNumber) && 
                string.Equals(OriginStanox, other.OriginStanox) && 
                OriginDepartureTimestamp.Equals(other.OriginDepartureTimestamp) && 
                CallType == other.CallType && 
                CallMode == other.CallMode && 
                string.Equals(TocId, other.TocId) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode) && 
                string.Equals(TrainFileAddress, other.TrainFileAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TrainActivation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) MessageType;
                hashCode = (hashCode*397) ^ (SourceDeviceId != null ? SourceDeviceId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (SourceSystemId != null ? SourceSystemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OriginalDataSource != null ? OriginalDataSource.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainId != null ? TrainId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ EventTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ OriginTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (TrainUid != null ? TrainUid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ScheduleOriginStanox != null ? ScheduleOriginStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ ScheduleStartDate.GetHashCode();
                hashCode = (hashCode*397) ^ ScheduleEndDate.GetHashCode();
                hashCode = (hashCode*397) ^ (int) ScheduleSource;
                hashCode = (hashCode*397) ^ (int) ScheduleType;
                hashCode = (hashCode*397) ^ (ScheduleWttId != null ? ScheduleWttId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DRecordNumber != null ? DRecordNumber.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OriginStanox != null ? OriginStanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OriginDepartureTimestamp.GetHashCode();
                hashCode = (hashCode*397) ^ (int) CallType;
                hashCode = (hashCode*397) ^ (int) CallMode;
                hashCode = (hashCode*397) ^ (TocId != null ? TocId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainFileAddress != null ? TrainFileAddress.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
