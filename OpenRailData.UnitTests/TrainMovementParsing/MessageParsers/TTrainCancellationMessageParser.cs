using System;
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

        [Theory]
        [InlineData("{\"header\":{\"msg_type\":\"0002\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"\",\"msg_queue_timestamp\":\"1464114807000\",\"source_system_id\":\"TRUST\"},\"body\":{\"train_file_address\":null,\"train_service_code\":\"51462180\",\"orig_loc_stanox\":\"\",\"toc_id\":\"54\",\"dep_timestamp\":\"1464125580000\",\"division_code\":\"54\",\"loc_stanox\":\"23451\",\"canx_timestamp\":\"1464118380000\",\"canx_reason_code\":\"PD\",\"train_id\":\"234R77C724\",\"orig_loc_timestamp\":\"\",\"canx_type\":\"ON CALL\"}}")]
        public void train_cancellation_parser_does_not_throw_when_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}