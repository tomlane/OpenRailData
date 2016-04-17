namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class IndexChanges : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Schedule.Location", name: "ScheduleRecord_Id", newName: "ScheduleRecordEntity_Id");
            RenameIndex(table: "Schedule.Location", name: "IX_ScheduleRecord_Id", newName: "IX_ScheduleRecordEntity_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Schedule.Location", name: "IX_ScheduleRecordEntity_Id", newName: "IX_ScheduleRecord_Id");
            RenameColumn(table: "Schedule.Location", name: "ScheduleRecordEntity_Id", newName: "ScheduleRecord_Id");
        }
    }
}
