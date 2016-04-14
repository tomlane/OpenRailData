using System.Data.Entity.Migrations;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Schedule.Association",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordIdentity = c.Int(nullable: false),
                        MainTrainUid = c.String(),
                        AssocTrainUid = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(),
                        AssocDays = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        DateIndicator = c.Int(nullable: false),
                        Location = c.String(),
                        BaseLocationSuffix = c.String(),
                        AssocLocationSuffix = c.String(),
                        DiagramType = c.String(),
                        AssocType = c.Int(nullable: false),
                        StpIndicator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedule.Header",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordIdentity = c.Int(nullable: false),
                        MainFrameIdentity = c.String(),
                        DateOfExtract = c.DateTime(nullable: false),
                        TimeOfExtract = c.String(),
                        CurrentFileRef = c.String(),
                        LastFileRef = c.String(),
                        ExtractUpdateType = c.Int(nullable: false),
                        CifSoftwareVersion = c.String(),
                        UserExtractStartDate = c.DateTime(nullable: false),
                        UserExtractEndDate = c.DateTime(nullable: false),
                        MainFrameUser = c.String(),
                        MainFrameExtractDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedule.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordIdentity = c.Int(nullable: false),
                        Tiploc = c.String(),
                        WorkingArrival = c.String(),
                        PublicArrival = c.String(),
                        WorkingDeparture = c.String(),
                        PublicDeparture = c.String(),
                        Pass = c.String(),
                        Platform = c.String(),
                        Line = c.String(),
                        Path = c.String(),
                        EngineeringAllowance = c.Time(nullable: false, precision: 7),
                        PathingAllowance = c.Time(nullable: false, precision: 7),
                        LocationActivityString = c.String(),
                        LocationActivity = c.Int(nullable: false),
                        PerformanceAllowance = c.Time(nullable: false, precision: 7),
                        OrderTime = c.String(),
                        ScheduleRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Schedule.Record", t => t.ScheduleRecord_Id)
                .Index(t => t.ScheduleRecord_Id);
            
            CreateTable(
                "Schedule.Record",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordIdentity = c.Int(nullable: false),
                        TrainUid = c.String(),
                        UniqueId = c.String(),
                        DateRunsFrom = c.DateTime(nullable: false),
                        DateRunsTo = c.DateTime(),
                        RunningDays = c.Int(nullable: false),
                        BankHolidayRunning = c.Int(nullable: false),
                        TrainStatus = c.String(),
                        TrainCategory = c.String(),
                        TrainIdentity = c.String(),
                        HeadCode = c.String(),
                        CourseIndicator = c.String(),
                        TrainServiceCode = c.String(),
                        PortionId = c.String(),
                        PowerType = c.Int(nullable: false),
                        TimingLoad = c.String(),
                        Speed = c.Int(nullable: false),
                        OperatingCharacteristicsString = c.String(),
                        OperatingCharacteristics = c.Int(nullable: false),
                        SeatingClass = c.Int(nullable: false),
                        Sleepers = c.Int(nullable: false),
                        Reservations = c.Int(nullable: false),
                        ConnectionIndicator = c.String(),
                        CateringCode = c.Int(nullable: false),
                        ServiceBranding = c.Int(nullable: false),
                        StpIndicator = c.Int(nullable: false),
                        ServiceTypeFlags = c.Int(nullable: false),
                        UicCode = c.String(),
                        AtocCode = c.String(),
                        AtsCode = c.String(),
                        Rsid = c.String(),
                        DataSource = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Schedule.Tiploc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecordIdentity = c.Int(nullable: false),
                        TiplocCode = c.String(),
                        CapitalsIdentification = c.String(),
                        Nalco = c.String(),
                        Nlc = c.String(),
                        TpsDescription = c.String(),
                        Stanox = c.String(),
                        PoMcbCode = c.String(),
                        CrsCode = c.String(),
                        CapriDescription = c.String(),
                        OldTiploc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Schedule.Location", "ScheduleRecord_Id", "Schedule.Record");
            DropIndex("Schedule.Location", new[] { "ScheduleRecord_Id" });
            DropTable("Schedule.Tiploc");
            DropTable("Schedule.Record");
            DropTable("Schedule.Location");
            DropTable("Schedule.Header");
            DropTable("Schedule.Association");
        }
    }
}
