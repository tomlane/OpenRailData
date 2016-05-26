using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Migrations
{
    [DbContext(typeof(TrainDescriberContext))]
    partial class TrainDescriberContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenRailData.TrainDescriberStorage.EntityFramework.Entities.BerthMessageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaId");

                    b.Property<string>("FromBerth");

                    b.Property<int>("MessageType");

                    b.Property<DateTime?>("ReportingTime");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("ToBerth");

                    b.Property<string>("TrainDescription");

                    b.HasKey("Id");

                    b.ToTable("BerthMessage","TrainDescriber");
                });

            modelBuilder.Entity("OpenRailData.TrainDescriberStorage.EntityFramework.Entities.SignalMessageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("AreaId");

                    b.Property<string>("Data");

                    b.Property<int>("MessageType");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("SignalMessage","TrainDescriber");
                });
        }
    }
}
