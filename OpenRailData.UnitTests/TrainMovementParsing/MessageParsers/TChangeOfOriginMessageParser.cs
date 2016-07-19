using System;
using System.Collections.Generic;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TChangeOfOriginMessageParser
    {
        private ChangeOfOriginMessageParser BuildParser()
        {
            return new ChangeOfOriginMessageParser();
        }

        [Fact]
        public void change_of_origin_parser_throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(null));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(" \t "));
        }

        [Fact]
        public void change_of_origin_parser_returns_correct_message_key()
        {
            var expectedKey = "0006";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Theory]
        [MemberData("Messages")]
        public void change_of_origin_parser_parses_valid_records(string message, ChangeOfOrigin expected)
        {
            var parser = BuildParser();

            var result = parser.ParseMovementMessage(message);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Messages => new List<object[]>
        {
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0006\",\"source_dev_id\":\"LYUE\",\"user_id\":\"#QMTRC06\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464115280000\",\"source_system_id\":\"TRUST\"},\"body\":{\"reason_code\":null,\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"24657005\",\"toc_id\":\"80\",\"dep_timestamp\":\"1464120450000\",\"coo_timestamp\":\"1464118860000\",\"division_code\":\"80\",\"loc_stanox\":\"88466\",\"train_id\":\"882N66MY24\",\"original_loc_stanox\":\"\"}}",
                new ChangeOfOrigin
                {
                    TrainId = "882N66MY24",
                    TrainServiceCode = "24657005",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 24, 19, 41, 0),
                    SourceDeviceId = "LYUE",
                    OriginalDataSource = "TRUST DA",
                    SourceSystemId = "TRUST",
                    CurrentTrainId = string.Empty,
                    TocId = "80",
                    OriginalLocationStanox = string.Empty,
                    OriginalLocationTimestamp = null,
                    LocationStanox = "88466",
                    DivisionCode = "80",
                    DepartureTimestamp = new DateTime(2016, 5, 24, 20, 7, 30),
                    ReasonCode = string.Empty
                }
            },
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0006\",\"source_dev_id\":\"LYJ8\",\"user_id\":\"#QHPA012\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464542760000\",\"source_system_id\":\"TRUST\"},\"body\":{\"reason_code\":null,\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"22215003\",\"toc_id\":\"30\",\"dep_timestamp\":\"1464545610000\",\"coo_timestamp\":\"1464546360000\",\"division_code\":\"30\",\"loc_stanox\":\"52088\",\"train_id\":\"529A52MV29\",\"original_loc_stanox\":\"\"}}",
                new ChangeOfOrigin
                {
                    TrainServiceCode = "22215003",
                    TrainId = "529A52MV29",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 29, 18, 26, 0),
                    SourceDeviceId = "LYJ8",
                    OriginalDataSource = "TRUST DA",
                    SourceSystemId = "TRUST",
                    CurrentTrainId = string.Empty,
                    TocId = "30",
                    OriginalLocationStanox = string.Empty,
                    OriginalLocationTimestamp = null,
                    LocationStanox = "52088",
                    DivisionCode = "30",
                    DepartureTimestamp = new DateTime(2016, 5, 29, 18, 13, 30),
                    ReasonCode = string.Empty
                } 
            }
        };
    }
}