using System.Data.Entity.Migrations;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Migrations
{
    public partial class ScheduleLocationCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Schedule.Location", "ScheduleRecord_Id", "Schedule.Record");
            AddForeignKey("Schedule.Location", "ScheduleRecord_Id", "Schedule.Record", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Schedule.Location", "ScheduleRecord_Id", "Schedule.Record");
            AddForeignKey("Schedule.Location", "ScheduleRecord_Id", "Schedule.Record", "Id");
        }
    }
}
