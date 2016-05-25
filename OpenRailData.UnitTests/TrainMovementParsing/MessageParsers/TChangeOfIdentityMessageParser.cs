using System;
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
        [InlineData("")]
        public void change_of_origin_parser_does_not_throw_while_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}