using System;
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
        [InlineData("{\"header\":{\"msg_type\":\"0006\",\"source_dev_id\":\"LYUE\",\"user_id\":\"#QMTRC06\",\"original_data_source\":\"TRUST DA\",\"msg_queue_timestamp\":\"1464115280000\",\"source_system_id\":\"TRUST\"},\"body\":{\"reason_code\":null,\"current_train_id\":\"\",\"original_loc_timestamp\":\"\",\"train_file_address\":null,\"train_service_code\":\"24657005\",\"toc_id\":\"80\",\"dep_timestamp\":\"1464120450000\",\"coo_timestamp\":\"1464118860000\",\"division_code\":\"80\",\"loc_stanox\":\"88466\",\"train_id\":\"882N66MY24\",\"original_loc_stanox\":\"\"}}")]
        public void change_of_origin_parser_does_not_throw_while_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}