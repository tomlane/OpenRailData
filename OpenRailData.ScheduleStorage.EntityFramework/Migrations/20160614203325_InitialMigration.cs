using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRailData.ScheduleStorage.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Schedule");

            migrationBuilder.CreateTable(
                name: "Association",
                schema: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssocDays = table.Column<int>(nullable: false),
                    AssocLocationSuffix = table.Column<string>(nullable: true),
                    AssocTrainUid = table.Column<string>(nullable: true),
                    AssocType = table.Column<int>(nullable: false),
                    BaseLocationSuffix = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    DateIndicator = table.Column<int>(nullable: false),
                    DiagramType = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    MainTrainUid = table.Column<string>(nullable: true),
                    RecordIdentity = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StpIndicator = table.Column<int>(nullable: false),
                    UniqueId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Header",
                schema: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CifSoftwareVersion = table.Column<string>(nullable: true),
                    CurrentFileRef = table.Column<string>(nullable: true),
                    DateOfExtract = table.Column<DateTime>(nullable: false),
                    ExtractUpdateType = table.Column<int>(nullable: false),
                    LastFileRef = table.Column<string>(nullable: true),
                    MainFrameExtractDate = table.Column<DateTime>(nullable: false),
                    MainFrameIdentity = table.Column<string>(nullable: true),
                    MainFrameUser = table.Column<string>(nullable: true),
                    RecordIdentity = table.Column<int>(nullable: false),
                    TimeOfExtract = table.Column<string>(nullable: true),
                    UserExtractEndDate = table.Column<DateTime>(nullable: true),
                    UserExtractStartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                schema: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtocCode = table.Column<string>(nullable: true),
                    AtsCode = table.Column<string>(nullable: true),
                    BankHolidayRunning = table.Column<int>(nullable: false),
                    CateringCode = table.Column<int>(nullable: false),
                    ConnectionIndicator = table.Column<string>(nullable: true),
                    CourseIndicator = table.Column<string>(nullable: true),
                    DataSource = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    HeadCode = table.Column<string>(nullable: true),
                    OperatingCharacteristics = table.Column<int>(nullable: false),
                    OperatingCharacteristicsString = table.Column<string>(nullable: true),
                    PortionId = table.Column<string>(nullable: true),
                    PowerType = table.Column<int>(nullable: false),
                    RecordIdentity = table.Column<int>(nullable: false),
                    Reservations = table.Column<int>(nullable: false),
                    Rsid = table.Column<string>(nullable: true),
                    RunningDays = table.Column<int>(nullable: false),
                    SeatingClass = table.Column<int>(nullable: false),
                    ServiceBranding = table.Column<int>(nullable: false),
                    ServiceTypeFlags = table.Column<int>(nullable: false),
                    Sleepers = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StpIndicator = table.Column<int>(nullable: false),
                    TimingLoad = table.Column<string>(nullable: true),
                    TrainCategory = table.Column<string>(nullable: true),
                    TrainIdentity = table.Column<string>(nullable: true),
                    TrainServiceCode = table.Column<string>(nullable: true),
                    TrainStatus = table.Column<string>(nullable: true),
                    TrainUid = table.Column<string>(nullable: true),
                    UicCode = table.Column<string>(nullable: true),
                    UniqueId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiploc",
                schema: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CapitalsIdentification = table.Column<string>(nullable: true),
                    CapriDescription = table.Column<string>(nullable: true),
                    CrsCode = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    Nalco = table.Column<string>(nullable: true),
                    Nlc = table.Column<string>(nullable: true),
                    OldTiploc = table.Column<string>(nullable: true),
                    PoMcbCode = table.Column<string>(nullable: true),
                    RecordIdentity = table.Column<int>(nullable: false),
                    Stanox = table.Column<string>(nullable: true),
                    TiplocCode = table.Column<string>(nullable: true),
                    TpsDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiploc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EngineeringAllowance = table.Column<TimeSpan>(nullable: false),
                    Line = table.Column<string>(nullable: true),
                    LocationActivity = table.Column<int>(nullable: false),
                    LocationActivityString = table.Column<string>(nullable: true),
                    OrderTime = table.Column<string>(nullable: true),
                    Pass = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    PathingAllowance = table.Column<TimeSpan>(nullable: false),
                    PerformanceAllowance = table.Column<TimeSpan>(nullable: false),
                    Platform = table.Column<string>(nullable: true),
                    PublicArrival = table.Column<string>(nullable: true),
                    PublicDeparture = table.Column<string>(nullable: true),
                    RecordIdentity = table.Column<int>(nullable: false),
                    ScheduleRecordEntityId = table.Column<Guid>(nullable: true),
                    Tiploc = table.Column<string>(nullable: true),
                    WorkingArrival = table.Column<string>(nullable: true),
                    WorkingDeparture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Record_ScheduleRecordEntityId",
                        column: x => x.ScheduleRecordEntityId,
                        principalSchema: "Schedule",
                        principalTable: "Record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_ScheduleRecordEntityId",
                schema: "Schedule",
                table: "Location",
                column: "ScheduleRecordEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Association",
                schema: "Schedule");

            migrationBuilder.DropTable(
                name: "Header",
                schema: "Schedule");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Schedule");

            migrationBuilder.DropTable(
                name: "Tiploc",
                schema: "Schedule");

            migrationBuilder.DropTable(
                name: "Record",
                schema: "Schedule");
        }
    }
}
