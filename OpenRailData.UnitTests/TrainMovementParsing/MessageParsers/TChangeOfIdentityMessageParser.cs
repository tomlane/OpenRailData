using System;
using System.Collections.Generic;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TChangeOfIdentityMessageParser
    {
        private ChangeOfIdentityMessageParser BuildParser()
        {
            return new ChangeOfIdentityMessageParser();
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
            var expectedKey = "0007";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Theory]
        [MemberData("Messages")]
        public void change_of_origin_parser_parses_valid_records(string message, ChangeOfIdentity expected)
        {
            var parser = BuildParser();

            var result = parser.ParseMovementMessage(message);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object> Messages => new List<object[]>
        {
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0007\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"TSIA\",\"msg_queue_timestamp\":\"1464215571000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"train_file_address\":null,\"train_service_code\":\"56121720\",\"revised_train_id\":\"52728LC426\",\"train_id\":\"52609JC426\",\"event_timestamp\":\"1464236100000\"}}",
                new ChangeOfIdentity
                {
                    TrainServiceCode = "56121720",
                    TrainId = "52609JC426",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 26, 4, 15, 0),
                    SourceDeviceId = string.Empty,
                    OriginalDataSource = "TSIA",
                    SourceSystemId = "TRUST",
                    CurrentTrainId = string.Empty,
                    RevisedTrainId = "52728LC426"
                }
            },
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0007\",\"source_dev_id\":\"X382240\",\"user_id\":\"\",\"original_data_source\":\"TOPS\",\"msg_queue_timestamp\":\"1464280351000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"train_file_address\":\"LGX\",\"train_service_code\":\"53790121\",\"revised_train_id\":\"88062PCW26\",\"train_id\":\"88778LCW26\",\"event_timestamp\":\"1464283932000\"}}",
                new ChangeOfIdentity
                {
                    TrainId = "88778LCW26",
                    TrainServiceCode = "53790121",
                    TrainFileAddress = "LGX",
                    EventTimestamp = new DateTime(2016, 5, 26, 17, 32, 12),
                    SourceDeviceId = "X382240",
                    OriginalDataSource = "TOPS",
                    SourceSystemId = "TRUST",
                    CurrentTrainId = string.Empty,
                    RevisedTrainId = "88062PCW26"
                }
            },
            new object[]
            {
                "{\"header\":{\"msg_type\":\"0007\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"TSIA\",\"msg_queue_timestamp\":\"1464281357000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"train_file_address\":null,\"train_service_code\":\"52495100\",\"revised_train_id\":\"65067PCY26\",\"train_id\":\"65610PCY26\",\"event_timestamp\":\"1464289200000\"}}",
                new ChangeOfIdentity
                {
                    TrainServiceCode = "52495100",
                    TrainId = "65610PCY26",
                    TrainFileAddress = string.Empty,
                    EventTimestamp = new DateTime(2016, 5, 26, 19, 0, 0),
                    SourceDeviceId = string.Empty,
                    OriginalDataSource = "TSIA",
                    SourceSystemId = "TRUST",
                    CurrentTrainId = string.Empty,
                    RevisedTrainId = "65067PCY26"
                } 
            }
        };
    }
}
