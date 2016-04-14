﻿using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTiplocDeleteCifRecordParser
    {
        private static TiplocDeleteCifRecordParser BuildParser()
        {
            return new TiplocDeleteCifRecordParser();
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("TD", parser.RecordKey);
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "TD1234567                                                                       ";
            var expectedResult = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TD,
                TiplocCode = "1234567"
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
