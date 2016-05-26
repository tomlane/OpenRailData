using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenRailData.Modules.ScheduleStorage.EntityFramework;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    partial class ScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.AssociationRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssocDays");

                    b.Property<string>("AssocLocationSuffix");

                    b.Property<string>("AssocTrainUid");

                    b.Property<int>("AssocType");

                    b.Property<string>("BaseLocationSuffix");

                    b.Property<int>("Category");

                    b.Property<DateTime>("DateFrom");

                    b.Property<int>("DateIndicator");

                    b.Property<DateTime?>("DateTo");

                    b.Property<string>("DiagramType");

                    b.Property<string>("Location");

                    b.Property<string>("MainTrainUid");

                    b.Property<int>("RecordIdentity");

                    b.Property<int>("StpIndicator");

                    b.HasKey("Id");

                    b.ToTable("Association","Schedule");
                });

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.HeaderRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CifSoftwareVersion");

                    b.Property<string>("CurrentFileRef");

                    b.Property<DateTime>("DateOfExtract");

                    b.Property<int>("ExtractUpdateType");

                    b.Property<string>("LastFileRef");

                    b.Property<DateTime>("MainFrameExtractDate");

                    b.Property<string>("MainFrameIdentity");

                    b.Property<string>("MainFrameUser");

                    b.Property<int>("RecordIdentity");

                    b.Property<string>("TimeOfExtract");

                    b.Property<DateTime>("UserExtractEndDate");

                    b.Property<DateTime>("UserExtractStartDate");

                    b.HasKey("Id");

                    b.ToTable("Header","Schedule");
                });

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.ScheduleLocationRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("EngineeringAllowance");

                    b.Property<string>("Line");

                    b.Property<int>("LocationActivity");

                    b.Property<string>("LocationActivityString");

                    b.Property<string>("OrderTime");

                    b.Property<string>("Pass");

                    b.Property<string>("Path");

                    b.Property<TimeSpan>("PathingAllowance");

                    b.Property<TimeSpan>("PerformanceAllowance");

                    b.Property<string>("Platform");

                    b.Property<string>("PublicArrival");

                    b.Property<string>("PublicDeparture");

                    b.Property<int>("RecordIdentity");

                    b.Property<int?>("ScheduleRecordEntityId");

                    b.Property<string>("Tiploc");

                    b.Property<string>("WorkingArrival");

                    b.Property<string>("WorkingDeparture");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleRecordEntityId");

                    b.ToTable("Location","Schedule");
                });

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.ScheduleRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtocCode");

                    b.Property<string>("AtsCode");

                    b.Property<int>("BankHolidayRunning");

                    b.Property<int>("CateringCode");

                    b.Property<string>("ConnectionIndicator");

                    b.Property<string>("CourseIndicator");

                    b.Property<string>("DataSource");

                    b.Property<DateTime>("DateRunsFrom");

                    b.Property<DateTime?>("DateRunsTo");

                    b.Property<string>("HeadCode");

                    b.Property<int>("OperatingCharacteristics");

                    b.Property<string>("OperatingCharacteristicsString");

                    b.Property<string>("PortionId");

                    b.Property<int>("PowerType");

                    b.Property<int>("RecordIdentity");

                    b.Property<int>("Reservations");

                    b.Property<string>("Rsid");

                    b.Property<int>("RunningDays");

                    b.Property<int>("SeatingClass");

                    b.Property<int>("ServiceBranding");

                    b.Property<int>("ServiceTypeFlags");

                    b.Property<int>("Sleepers");

                    b.Property<int>("Speed");

                    b.Property<int>("StpIndicator");

                    b.Property<string>("TimingLoad");

                    b.Property<string>("TrainCategory");

                    b.Property<string>("TrainIdentity");

                    b.Property<string>("TrainServiceCode");

                    b.Property<string>("TrainStatus");

                    b.Property<string>("TrainUid");

                    b.Property<string>("UicCode");

                    b.Property<string>("UniqueId");

                    b.HasKey("Id");

                    b.ToTable("Record","Schedule");
                });

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.TiplocRecordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CapitalsIdentification");

                    b.Property<string>("CapriDescription");

                    b.Property<string>("CrsCode");

                    b.Property<string>("LocationName");

                    b.Property<string>("Nalco");

                    b.Property<string>("Nlc");

                    b.Property<string>("OldTiploc");

                    b.Property<string>("PoMcbCode");

                    b.Property<int>("RecordIdentity");

                    b.Property<string>("Stanox");

                    b.Property<string>("TiplocCode");

                    b.Property<string>("TpsDescription");

                    b.HasKey("Id");

                    b.ToTable("Tiploc","Schedule");
                });

            modelBuilder.Entity("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.ScheduleLocationRecordEntity", b =>
                {
                    b.HasOne("OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities.ScheduleRecordEntity")
                        .WithMany()
                        .HasForeignKey("ScheduleRecordEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
