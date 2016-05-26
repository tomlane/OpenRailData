using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenRailData.TrainDescriberStorage.EntityFramework;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Migrations
{
    [DbContext(typeof(TrainDescriberContext))]
    [Migration("20160526214833_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
