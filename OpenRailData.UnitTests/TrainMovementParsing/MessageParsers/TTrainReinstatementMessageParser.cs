using System;
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
        [InlineData("{\"header\":{\"msg_type\":\"0005\",\"source_dev_id\":\"LYJ8\",\"user_id\":\"#QDP0057\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464154821000\",\"source_system_id\":\"TRUST\"},\"body\":{\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"25375002\",\"toc_id\":\"25\",\"dep_timestamp\":\"1464152280000\",\"division_code\":\"25\",\"loc_stanox\":\"79304\",\"train_id\":\"791L08M425\",\"original_loc_stanox\":\"\",\"reinstatement_timestamp\":\"1464158400000\"}}")]
        public void train_reinstatement_parser_does_not_throw_while_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}