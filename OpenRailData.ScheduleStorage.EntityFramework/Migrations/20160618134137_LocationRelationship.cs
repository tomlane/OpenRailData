using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRailData.ScheduleStorage.EntityFramework.Migrations
{
    public partial class LocationRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleRecordId",
                schema: "Schedule",
                table: "Location",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_ScheduleRecordId",
                schema: "Schedule",
                table: "Location",
                column: "ScheduleRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Record_ScheduleRecordId",
                schema: "Schedule",
                table: "Location",
                column: "ScheduleRecordId",
                principalSchema: "Schedule",
                principalTable: "Record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Record_ScheduleRecordId",
                schema: "Schedule",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_ScheduleRecordId",
                schema: "Schedule",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ScheduleRecordId",
                schema: "Schedule",
                table: "Location");
        }
    }
}
