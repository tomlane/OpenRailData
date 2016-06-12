using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TrainMovements");

            migrationBuilder.CreateTable(
                name: "ChangeOfIdentity",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentTrainId = table.Column<string>(nullable: true),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    RevisedTrainId = table.Column<string>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeOfIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeOfOrigin",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentTrainId = table.Column<string>(nullable: true),
                    DepartureTimestamp = table.Column<DateTime>(nullable: true),
                    DivisionCode = table.Column<string>(nullable: true),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    LocationStanox = table.Column<string>(nullable: true),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    OriginalLocationStanox = table.Column<string>(nullable: true),
                    OriginalLocationTimestamp = table.Column<DateTime>(nullable: true),
                    ReasonCode = table.Column<string>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    TocId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeOfOrigin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainActivation",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CallMode = table.Column<int>(nullable: false),
                    CallType = table.Column<int>(nullable: false),
                    DRecordNumber = table.Column<string>(nullable: true),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    OriginDepartureTimestamp = table.Column<DateTime>(nullable: true),
                    OriginStanox = table.Column<string>(nullable: true),
                    OriginTimestamp = table.Column<DateTime>(nullable: false),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    ScheduleEndDate = table.Column<DateTime>(nullable: false),
                    ScheduleOriginStanox = table.Column<string>(nullable: true),
                    ScheduleSource = table.Column<int>(nullable: false),
                    ScheduleStartDate = table.Column<DateTime>(nullable: false),
                    ScheduleType = table.Column<int>(nullable: false),
                    ScheduleWttId = table.Column<string>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    TocId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true),
                    TrainUid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainActivation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainCancellation",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CancellationType = table.Column<int>(nullable: false),
                    DepartureTimestamp = table.Column<DateTime>(nullable: true),
                    DivisionCode = table.Column<string>(nullable: true),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    LocationStanox = table.Column<string>(nullable: true),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    OriginalLocationStanox = table.Column<string>(nullable: true),
                    OriginalLocationTimestamp = table.Column<DateTime>(nullable: true),
                    ReasonCode = table.Column<string>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    TocId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainCancellation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainMovement",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AutoExpected = table.Column<bool>(nullable: false),
                    Correction = table.Column<bool>(nullable: false),
                    CurrentTrainId = table.Column<string>(nullable: true),
                    DelayMonitoringPoint = table.Column<bool>(nullable: false),
                    Direction = table.Column<int>(nullable: false),
                    DivisionCode = table.Column<string>(nullable: true),
                    EventSource = table.Column<int>(nullable: false),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    LocationStanox = table.Column<string>(nullable: true),
                    NextReportRunTime = table.Column<int>(nullable: false),
                    NextReportStanox = table.Column<string>(nullable: true),
                    OffRoute = table.Column<bool>(nullable: false),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    OriginalLocationStanox = table.Column<string>(nullable: true),
                    OriginalLocationTimestamp = table.Column<DateTime>(nullable: true),
                    PassengerTimestamp = table.Column<DateTime>(nullable: true),
                    PlannedEventType = table.Column<int>(nullable: false),
                    PlannedTimestamp = table.Column<DateTime>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    ReportingStanox = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    Terminated = table.Column<bool>(nullable: false),
                    TimetableVariation = table.Column<int>(nullable: false),
                    TocId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true),
                    VariationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainMovement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainReinstatement",
                schema: "TrainMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentTrainId = table.Column<string>(nullable: true),
                    DepartureTimestamp = table.Column<DateTime>(nullable: true),
                    DivisionCode = table.Column<string>(nullable: true),
                    EventTimestamp = table.Column<DateTime>(nullable: false),
                    LocationStanox = table.Column<string>(nullable: true),
                    OriginalDataSource = table.Column<string>(nullable: true),
                    OriginalLocationStanox = table.Column<string>(nullable: true),
                    OriginalLocationTimestamp = table.Column<DateTime>(nullable: true),
                    SourceDeviceId = table.Column<string>(nullable: true),
                    SourceSystemId = table.Column<string>(nullable: true),
                    TocId = table.Column<string>(nullable: true),
                    TrainFileAddress = table.Column<string>(nullable: true),
                    TrainId = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainReinstatement", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeOfIdentity",
                schema: "TrainMovements");

            migrationBuilder.DropTable(
                name: "ChangeOfOrigin",
                schema: "TrainMovements");

            migrationBuilder.DropTable(
                name: "TrainActivation",
                schema: "TrainMovements");

            migrationBuilder.DropTable(
                name: "TrainCancellation",
                schema: "TrainMovements");

            migrationBuilder.DropTable(
                name: "TrainMovement",
                schema: "TrainMovements");

            migrationBuilder.DropTable(
                name: "TrainReinstatement",
                schema: "TrainMovements");
        }
    }
}
