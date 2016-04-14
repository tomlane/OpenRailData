using System.Data.Entity.Migrations;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Migrations
{
    public partial class LocationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("Schedule.Tiploc", "LocationName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Schedule.Tiploc", "LocationName");
        }
    }
}
