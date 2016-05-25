using System;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TTrainActivationMessageParser
    {
        private TrainActivationMessageParser BuildParser()
        {
            return new TrainActivationMessageParser();
        }

        [Fact]
        public void train_activation_parser_throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(null));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(" \t "));
        }

        [Fact]
        public void train_activation_parser_returns_correct_message_key()
        {
            var expectedKey = "0001";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Theory]
        [InlineData("{\"header\":{\"msg_type\":\"0001\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"TSIA\",\"msg_queue_timestamp\":\"1464114805000\",\"source_system_id\":\"TRUST\"},\"body\":{\"schedule_source\":\"C\",\"train_file_address\":null,\"schedule_end_date\":\"2016-12-09\",\"train_id\":\"575F68M724\",\"tp_origin_timestamp\":\"2016-05-24\",\"creation_timestamp\":\"1464118405000\",\"tp_origin_stanox\":\"\",\"origin_dep_timestamp\":\"1464125580000\",\"train_service_code\":\"22150007\",\"toc_id\":\"28\",\"d1266_record_number\":\"00000\",\"train_call_type\":\"AUTOMATIC\",\"train_uid\":\"C65582\",\"train_call_mode\":\"NORMAL\",\"schedule_type\":\"O\",\"sched_origin_stanox\":\"57403\",\"schedule_wtt_id\":\"5F68M\",\"schedule_start_date\":\"2016-05-16\"}}")]
        public void train_activation_parser_does_not_throw_while_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}