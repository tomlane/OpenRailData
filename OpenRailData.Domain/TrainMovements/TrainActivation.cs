using System;
using OpenRailData.Domain.TrainMovements.Enums;

namespace OpenRailData.Domain.TrainMovements
{
    public class TrainActivation : ITrainMovementMessage
    {
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
    }
}
