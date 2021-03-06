﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenRailData.ScheduleStorage.EntityFramework.Migrations
{
    public partial class TiplocSuffix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TiplocSuffix",
                schema: "Schedule",
                table: "Location",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiplocSuffix",
                schema: "Schedule",
                table: "Location");
        }
    }
}
