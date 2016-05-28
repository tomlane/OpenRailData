using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Migrations
{
    [DbContext(typeof(TrainMovementContext))]
    partial class TrainMovementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.ChangeOfIdentityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentTrainId");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<string>("OriginalDataSource");

                    b.Property<string>("RevisedTrainId");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.HasKey("Id");

                    b.ToTable("ChangeOfIdentity","TrainMovements");
                });

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.ChangeOfOriginEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentTrainId");

                    b.Property<DateTime>("DepartureTimestamp");

                    b.Property<string>("DivisionCode");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<string>("LocationStanox");

                    b.Property<string>("OriginalDataSource");

                    b.Property<string>("OriginalLocationStanox");

                    b.Property<DateTime?>("OriginalLocationTimestamp");

                    b.Property<string>("ReasonCode");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<string>("TocId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.HasKey("Id");

                    b.ToTable("ChangeOfOrigin","TrainMovements");
                });

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.TrainActivationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CallMode");

                    b.Property<int>("CallType");

                    b.Property<string>("DRecordNumber");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<DateTime>("OriginDepartureTimestamp");

                    b.Property<string>("OriginStanox");

                    b.Property<DateTime>("OriginTimestamp");

                    b.Property<string>("OriginalDataSource");

                    b.Property<DateTime>("ScheduleEndDate");

                    b.Property<string>("ScheduleOriginStanox");

                    b.Property<int>("ScheduleSource");

                    b.Property<DateTime>("ScheduleStartDate");

                    b.Property<int>("ScheduleType");

                    b.Property<string>("ScheduleWttId");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<string>("TocId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.Property<string>("TrainUid");

                    b.HasKey("Id");

                    b.ToTable("TrainActivation","TrainMovements");
                });

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.TrainCancellationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CancellationType");

                    b.Property<DateTime>("DepartureTimestamp");

                    b.Property<string>("DivisionCode");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<string>("LocationStanox");

                    b.Property<string>("OriginalDataSource");

                    b.Property<string>("OriginalLocationStanox");

                    b.Property<DateTime?>("OriginalLocationTimestamp");

                    b.Property<string>("ReasonCode");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<string>("TocId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.HasKey("Id");

                    b.ToTable("TrainCancellation","TrainMovements");
                });

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.TrainMovementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentTrainId");

                    b.Property<int?>("Direction");

                    b.Property<string>("DivisionCode");

                    b.Property<int>("EventSource");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<int>("EventType");

                    b.Property<bool>("HasTerminated");

                    b.Property<bool>("IsAutoExpected");

                    b.Property<bool>("IsCorrection");

                    b.Property<bool>("IsDelayMonitoringPoint");

                    b.Property<bool>("IsOffRoute");

                    b.Property<string>("Line");

                    b.Property<string>("LocationStanox");

                    b.Property<int>("NextReportRunTime");

                    b.Property<string>("NextReportStanox");

                    b.Property<string>("OriginalDataSource");

                    b.Property<string>("OriginalLocationStanox");

                    b.Property<DateTime?>("OriginalLocationTimestamp");

                    b.Property<DateTime>("PassengerTimestamp");

                    b.Property<int>("PlannedEventType");

                    b.Property<DateTime>("PlannedTimestamp");

                    b.Property<string>("Platform");

                    b.Property<string>("ReportingStanox");

                    b.Property<string>("Route");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<int>("TimetableVariation");

                    b.Property<string>("TocId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.Property<int>("VariationStatus");

                    b.HasKey("Id");

                    b.ToTable("TrainMovement","TrainMovements");
                });

            modelBuilder.Entity("OpenRailData.TrainMovementStorage.EntityFramework.Entites.TrainReinstatementEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentTrainId");

                    b.Property<DateTime>("DepartureTimestamp");

                    b.Property<string>("DivisionCode");

                    b.Property<DateTime>("EventTimestamp");

                    b.Property<string>("LocationStanox");

                    b.Property<string>("OriginalDataSource");

                    b.Property<string>("OriginalLocationStanox");

                    b.Property<DateTime?>("OriginalLocationTimestamp");

                    b.Property<string>("SourceDeviceId");

                    b.Property<string>("SourceSystemId");

                    b.Property<string>("TocId");

                    b.Property<string>("TrainFileAddress");

                    b.Property<string>("TrainId");

                    b.Property<string>("TrainServiceCode");

                    b.HasKey("Id");

                    b.ToTable("TrainReinstatement","TrainMovements");
                });
        }
    }
}
