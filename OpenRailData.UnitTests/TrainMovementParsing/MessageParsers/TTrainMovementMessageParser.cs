using System;
using OpenRailData.TrainMovementParsing.Json.TrainMovementMessageParsers;
using Xunit;

namespace OpenRailData.UnitTests.TrainMovementParsing.MessageParsers
{
    public class TTrainMovementMessageParser
    {
        private TrainMovementMessageParser BuildParser()
        {
            return new TrainMovementMessageParser();
        }

        [Fact]
        public void train_movement_parser_throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(null));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseMovementMessage(" \t "));
        }

        [Fact]
        public void train_movement_parser_has_correct_message_type_key()
        {
            var expectedKey = "0003";

            var parser = BuildParser();

            Assert.Equal(expectedKey, parser.TrainMovementMessageType);
        }

        [Theory]
        [InlineData("{\"header\":{\"msg_type\":\"0003\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"SMART\",\"msg_queue_timestamp\":\"1464131529000\",\"source_system_id\":\"TRUST\"},\"body\":{\"event_type\":\"DEPARTURE\",\"gbtt_timestamp\":\"\",\"original_loc_stanox\":\"\",\"planned_timestamp\":\"1464135210000\",\"timetable_variation\":\"1\",\"original_loc_timestamp\":\"\",\"current_train_id\":\"\",\"delay_monitoring_point\":\"true\",\"next_report_run_time\":\"3\",\"reporting_stanox\":\"73775\",\"actual_timestamp\":\"1464135120000\",\"correction_ind\":\"false\",\"event_source\":\"AUTOMATIC\",\"train_file_address\":null,\"platform\":\"\",\"division_code\":\"25\",\"train_terminated\":\"false\",\"train_id\":\"732R93M924\",\"offroute_ind\":\"false\",\"variation_status\":\"EARLY\",\"train_service_code\":\"25516005\",\"toc_id\":\"25\",\"loc_stanox\":\"73775\",\"auto_expected\":\"true\",\"direction_ind\":\"DOWN\",\"route\":\"1\",\"planned_event_type\":\"DEPARTURE\",\"next_report_stanox\":\"73780\",\"line_ind\":\"R\"}}")]
        [InlineData("{\"header\":{\"msg_type\":\"0003\",\"source_dev_id\":\"VUBP\",\"user_id\":\"#EFG2041\",\"original_data_source\":\"SDR\",\"msg_queue_timestamp\":\"1464154797000\",\"source_system_id\":\"TRUST\"},\"body\":{\"event_type\":\"ARRIVAL\",\"gbtt_timestamp\":\"1464158100000\",\"original_loc_stanox\":\"\",\"planned_timestamp\":\"1464158070000\",\"timetable_variation\":\"1\",\"original_loc_timestamp\":\"\",\"current_train_id\":\"\",\"delay_monitoring_point\":\"false\",\"next_report_run_time\":\"1\",\"reporting_stanox\":\"00000\",\"actual_timestamp\":\"1464158100000\",\"correction_ind\":\"false\",\"event_source\":\"MANUAL\",\"train_file_address\":null,\"platform\":\"\",\"division_code\":\"25\",\"train_terminated\":\"false\",\"train_id\":\"851A77M525\",\"offroute_ind\":\"false\",\"variation_status\":\"LATE\",\"train_service_code\":\"25397003\",\"toc_id\":\"25\",\"loc_stanox\":\"85303\",\"auto_expected\":\"\",\"direction_ind\":\"\",\"route\":\"0\",\"planned_event_type\":\"ARRIVAL\",\"next_report_stanox\":\"85111\",\"line_ind\":\"\"}}")]
        [InlineData("{\"header\":{\"msg_type\":\"0003\",\"source_dev_id\":\"XR89735\",\"user_id\":\"\",\"original_data_source\":\"TOPS\",\"msg_queue_timestamp\":\"1464213318000\",\"source_system_id\":\"TRUST\"},\"body\":{\"event_type\":\"ARRIVAL\",\"gbtt_timestamp\":\"1464214740000\",\"original_loc_stanox\":\"\",\"planned_timestamp\":\"1464214740000\",\"timetable_variation\":\"0\",\"original_loc_timestamp\":\"\",\"current_train_id\":null,\"delay_monitoring_point\":\"true\",\"next_report_run_time\":\"\",\"reporting_stanox\":\"00713\",\"actual_timestamp\":\"1464214740000\",\"correction_ind\":\"false\",\"event_source\":\"MANUAL\",\"train_file_address\":\"JQ7\",\"platform\":\"\",\"division_code\":\"00\",\"train_terminated\":\"true\",\"train_id\":\"89414X2725\",\"offroute_ind\":\"false\",\"variation_status\":\"ON TIME\",\"train_service_code\":\"57610311\",\"toc_id\":\"00\",\"loc_stanox\":\"00713\",\"auto_expected\":\"false\",\"direction_ind\":\"\",\"route\":\"0\",\"planned_event_type\":\"DESTINATION\",\"next_report_stanox\":\"\",\"line_ind\":\"\"}}")]
        [InlineData("{\"header\":{\"msg_type\":\"0003\",\"source_dev_id\":\"\",\"user_id\":\"\",\"original_data_source\":\"SMART\",\"msg_queue_timestamp\":\"1464213027000\",\"source_system_id\":\"TRUST\"},\"body\":{\"event_type\":\"DEPARTURE\",\"gbtt_timestamp\":\"\",\"original_loc_stanox\":\"\",\"planned_timestamp\":\"\",\"timetable_variation\":\"0\",\"original_loc_timestamp\":\"\",\"current_train_id\":null,\"delay_monitoring_point\":\"false\",\"next_report_run_time\":\"\",\"reporting_stanox\":\"\",\"actual_timestamp\":\"1464216600000\",\"correction_ind\":\"false\",\"event_source\":\"AUTOMATIC\",\"train_file_address\":\"JX8\",\"platform\":\"\",\"division_code\":\"00\",\"train_terminated\":\"false\",\"train_id\":\"86615H1725\",\"offroute_ind\":\"true\",\"variation_status\":\"OFF ROUTE\",\"train_service_code\":\"52495100\",\"toc_id\":\"00\",\"loc_stanox\":\"86012\",\"auto_expected\":\"\",\"direction_ind\":\"\",\"route\":\"\",\"planned_event_type\":\"DEPARTURE\",\"next_report_stanox\":\"\",\"line_ind\":\"\"}}")]
        public void train_movement_parser_does_not_throw_when_parsing_valid_records(string message)
        {
            var parser = BuildParser();

            parser.ParseMovementMessage(message);
        }
    }
}