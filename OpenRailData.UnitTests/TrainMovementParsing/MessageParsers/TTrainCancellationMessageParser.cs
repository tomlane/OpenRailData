using System;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.Entities.Enums;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TTrainCancellationMessageParser
    {
        private TrainCancellationMessageParser BuildParser()
        {
            return new TrainCancellationMessageParser();
        }

        [Fact]
        public void train_cancellation_parser_throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(null));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(" \t "));
        }

        [Fact]
        public void train_cancellation_parser_returns_correct_message_key()
        {
            var expectedKey = "0002";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Fact]
        public void train_cancellation_parser_parses_cancellation_message()
        {
            var message = "{\"header\":{\"msg_type\":\"0002\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"\",\"msg_queue_timestamp\":\"1464114807000\",\"source_system_id\":\"TRUST\"},\"body\":{\"train_file_address\":null,\"train_service_code\":\"51462180\",\"orig_loc_stanox\":\"\",\"toc_id\":\"54\",\"dep_timestamp\":\"1464125580000\",\"division_code\":\"54\",\"loc_stanox\":\"23451\",\"canx_timestamp\":\"1464118380000\",\"canx_reason_code\":\"PD\",\"train_id\":\"234R77C724\",\"orig_loc_timestamp\":\"\",\"canx_type\":\"ON CALL\"}}";

            var cancellation = new TrainCancellation
            {
                TrainServiceCode = "51462180",
                TrainId = "234R77C724",
                TrainFileAddress = string.Empty,
                EventTimestamp = new DateTime(2016, 5, 24, 19, 33, 0),
                SourceDeviceId = string.Empty,
                OriginalDataSource = string.Empty,
                SourceSystemId = "TRUST",
                TocId = "54",
                OriginalLocationStanox = string.Empty,
                OriginalLocationTimestamp = null,
                LocationStanox = "23451",
                DivisionCode = "54",
                DepartureTimestamp = new DateTime(2016, 5, 24, 21, 33, 0),
                ReasonCode = "PD",
                CancellationType = CancellationType.ONCALL
            };

            var parser = BuildParser();

            var result = parser.ParseMovementMessage(message);

            Assert.Equal(cancellation, result);
        }
    }
}