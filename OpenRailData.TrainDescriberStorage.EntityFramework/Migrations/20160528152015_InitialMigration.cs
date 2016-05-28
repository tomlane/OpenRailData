using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TrainDescriber");

            migrationBuilder.CreateTable(
                name: "BerthMessage",
                schema: "TrainDescriber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<string>(nullable: true),
                    FromBerth = table.Column<string>(nullable: true),
                    MessageType = table.Column<int>(nullable: false),
                    ReportingTime = table.Column<DateTime>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    ToBerth = table.Column<string>(nullable: true),
                    TrainDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BerthMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignalMessage",
                schema: "TrainDescriber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AreaId = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    MessageType = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignalMessage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BerthMessage",
                schema: "TrainDescriber");

            migrationBuilder.DropTable(
                name: "SignalMessage",
                schema: "TrainDescriber");
        }
    }
}
