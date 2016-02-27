﻿using System;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTerminatingLocationCifRecordParser
    {
        private static IUnityContainer _container;
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        [SetUp]
        public void Setup()
        {
            _container = CifParserIocContainerBuilder.Build();
            _enumPropertyParsers = _container.Resolve<IRecordEnumPropertyParser[]>();
        }

        private TerminatingLocationCifRecordParser BuildParser()
        {
            return new TerminatingLocationCifRecordParser(_enumPropertyParsers);
        }

        [Test]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TerminatingLocationCifRecordParser(null));
        }

        [Test]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("LT", parser.RecordKey);
        }

        [Test]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(" \t "));
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "LTWSTBRYW 1323 13253     TF                                                     ";
            var expectedResult = new ScheduleLocationRecord
            {
                RecordIdentity = ScheduleRecordType.LT,
                Tiploc = "WSTBRYW",
                WorkingArrival = "1323",
                PublicArrival = "1325",
                Platform = "3",
                LocationActivity = LocationActivity.TF,
                LocationActivityString = "TF          ",
                OrderTime = "1323"
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
