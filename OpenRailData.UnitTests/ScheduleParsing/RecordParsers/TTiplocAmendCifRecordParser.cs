﻿using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TTiplocAmendCifRecordParser
    {
        private static TiplocAmendCifRecordParser BuildParser()
        {
            return new TiplocAmendCifRecordParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("TA", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";
            var expectedResult = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TA,
                TiplocCode = "0111193",
                CapitalsIdentification = "08",
                Nalco = "544815",
                Nlc = "B",
                TpsDescription = "EASTBOURNE C.S.",
                Stanox = "88253",
                PoMcbCode = "0",
                CrsCode = "XEB",
                CapriDescription = string.Empty,
                OldTiploc = "EBOUCS"
            };

            var result = recordParser.ParseRecord(recordToParse) as TiplocRecord;
            
            Assert.Equal(expectedResult, result);
        }
    }
}
