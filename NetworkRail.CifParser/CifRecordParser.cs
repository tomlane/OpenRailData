﻿using System;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifRecordParser : ICifRecordParser
    {
        private readonly ICifRecordBuilderContainer _cifRecordBuilderContainer;

        public CifRecordParser(ICifRecordBuilderContainer cifRecordBuilderContainer)
        {
            if (cifRecordBuilderContainer == null)
                throw new ArgumentNullException(nameof(cifRecordBuilderContainer));

            _cifRecordBuilderContainer = cifRecordBuilderContainer;
        }

        public ICifRecord ParseRecord(string record)
        {
            if (string.IsNullOrWhiteSpace(record))
                throw new ArgumentNullException(nameof(record));

            if (record.Length != 80)
                throw new ArgumentOutOfRangeException($"The CIF record must have a length of 80 characters. Current record length: {record.Length}");

            string recordType = record.Substring(0, 2);

            switch (recordType)
            {
                case "HD":
                    return _cifRecordBuilderContainer.HeaderRecordParser.BuildRecord(record);
                case "TI":
                    return _cifRecordBuilderContainer.TiplocInsertAmendRecordParser.BuildRecord(record);
                case "TA":
                    return _cifRecordBuilderContainer.TiplocInsertAmendRecordParser.BuildRecord(record);
                case "AA":
                    return _cifRecordBuilderContainer.AssociationRecordParser.BuildRecord(record);
                case "BS":
                    return _cifRecordBuilderContainer.BasicScheduleRecordParser.BuildRecord(record);
                case "BX":
                    return _cifRecordBuilderContainer.BasicScheduleExtraDetailsRecordParser.BuildRecord(record);
                case "LO":
                    return _cifRecordBuilderContainer.LocationRecordParser.BuildRecord(record);
                case "LI":
                    return _cifRecordBuilderContainer.LocationRecordParser.BuildRecord(record);
                case "CR":
                    return _cifRecordBuilderContainer.ChangesEnRouteRecordParser.BuildRecord(record);
                case "LT":
                    return _cifRecordBuilderContainer.LocationRecordParser.BuildRecord(record);
                case "ZZ":
                    return new EndOfFileRecord();
                default:
                    throw new NotImplementedException($"The following record type has not been implemented: {recordType}");
            }
        }
    }
}