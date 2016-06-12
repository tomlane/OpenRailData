using System;
using System.Collections.Generic;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TTrainReinstatementMessageParser
    {
        private TrainReinstatementMessageParser BuildParser()
        {
            return new TrainReinstatementMessageParser();
        }

        [Fact]
        public void train_reinstatement_parser_throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(null));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(" \t "));
        }

        [Fact]
        public void train_reinstatement_parser_returns_correct_message_key()
        {
            var expectedKey = "0005";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Theory]
        [MemberData("Messages")]
        public void train_reinstatement_parser_does_not_throw_while_parsing_valid_records(string message, TrainReinstatement expected)
        {
            var parser = BuildParser();

            var result = parser.ParseMovementMessage(message);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Messages => new List<object[]>
        {
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0005\",\"source_dev_id\":\"L0BL\",\"user_id\":\"#QBP0013\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464275090000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"24745000\",\"toc_id\":\"88\",\"dep_timestamp\":\"1464286440000\",\"division_code\":\"88\",\"loc_stanox\":\"87089\",\"train_id\":\"872A78MW26\",\"original_loc_stanox\":\"\",\"reinstatement_timestamp\":\"1464278640000\"}}",
                new TrainReinstatement
                {
                    TrainId = "872A78MW26",
                    TrainServiceCode = "24745000",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 26, 16, 4, 0),
                    SourceDeviceId = "L0BL",
                    SourceSystemId = "TRUST",
                    OriginalDataSource = "TRUST DA",
                    CurrentTrainId = string.Empty,
                    TocId = "88",
                    OriginalLocationStanox = string.Empty,
                    OriginalLocationTimestamp = null,
                    LocationStanox = "87089",
                    DivisionCode = "88",
                    DepartureTimestamp = new DateTime(2016, 5, 26, 18, 14, 0)
                }
            },
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0005\",\"source_dev_id\":\"LYJ8\",\"user_id\":\"#QRP4137\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464542347000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"25211004\",\"toc_id\":\"74\",\"dep_timestamp\":\"1464544920000\",\"division_code\":\"74\",\"loc_stanox\":\"63021\",\"train_id\":\"635I572W29\",\"original_loc_stanox\":\"\",\"reinstatement_timestamp\":\"1464545940000\"}}",
                new TrainReinstatement
                {
                    TrainServiceCode = "25211004",
                    TrainId = "635I572W29",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 29, 18, 19, 0),
                    SourceDeviceId = "LYJ8",
                    SourceSystemId = "TRUST",
                    OriginalDataSource = "TRUST DA",
                    CurrentTrainId = string.Empty,
                    TocId = "74",
                    OriginalLocationStanox = string.Empty,
                    OriginalLocationTimestamp = null,
                    LocationStanox = "63021",
                    DivisionCode = "74",
                    DepartureTimestamp = new DateTime(2016, 5, 29, 18, 2, 0)
                }
            }
        };
    }
}