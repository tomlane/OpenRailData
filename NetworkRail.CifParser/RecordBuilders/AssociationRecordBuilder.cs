﻿using System;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class AssociationRecordBuilder : ICifRecordBuilder<AssociationRecord>
    {
        private readonly IAssociationRecordParserContainer _recordParserContainer;

        public AssociationRecordBuilder(IAssociationRecordParserContainer recordParserContainer)
        {
            if (recordParserContainer == null)
                throw new ArgumentNullException(nameof(recordParserContainer));

            _recordParserContainer = recordParserContainer;
        }

        public AssociationRecord BuildRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            AssociationRecord record = new AssociationRecord
            {
                TransactionType = _recordParserContainer.TransactionTypeParser.ParseTransactionType(recordString.Substring(2, 1)),
                MainTrainUid = recordString.Substring(3, 6),
                AssocTrainUid = recordString.Substring(9, 6),
                DateFrom = _recordParserContainer.DateTimeParser.ParseDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yymmdd",
                    DateTimeString = recordString.Substring(15, 6)
                }),
                DateTo = _recordParserContainer.DateTimeParser.ParseNullableDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yymmdd",
                    DateTimeString = recordString.Substring(21, 6)
                }),
                AssocDays = _recordParserContainer.RunningDaysParser.ParseRunningDays(recordString.Substring(27, 7)),
                Category = _recordParserContainer.AssociationCategoryParser.ParseAssociationCategory(recordString.Substring(34, 2)),
                DateIndicator = _recordParserContainer.DateIndicatorParser.ParseDateIndicator(recordString.Substring(36, 1)),
                Location = recordString.Substring(37, 7).Trim(),
                BaseLocationSuffix = recordString.Substring(44, 1).Trim(),
                AssocLocationSuffix = recordString.Substring(45, 1).Trim(),
                DiagramType = recordString.Substring(46, 1).Trim(),
                StpIndicator = _recordParserContainer.StpIndicatorParser.ParseStpIndicator(recordString.Substring(79, 1))
            };

            return record;
        }
    }
}