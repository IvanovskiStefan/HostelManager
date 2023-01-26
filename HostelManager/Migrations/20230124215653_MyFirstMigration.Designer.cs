﻿// <auto-generated />
using HosteManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HostelManager.Migrations
{
    [DbContext(typeof(HostelManagerDbContex))]
    [Migration("20230124215653_MyFirstMigration")]
    partial class MyFirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HostelManager.Domain.Guest", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Stefan",
                            LastName = "Ivanovski",
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Marija",
                            LastName = "Magdalena",
                            RoomId = 2
                        });
                });

            modelBuilder.Entity("HostelManager.Domain.Hostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hostels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Partizanski Odredi",
                            HostelName = "NumberOne"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Kliment Ohridski",
                            HostelName = "NumberTwo"
                        });
                });

            modelBuilder.Entity("HostelManager.Domain.Room", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("HostelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 3,
                            HostelId = 1,
                            IsAvailable = true
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 4,
                            HostelId = 2,
                            IsAvailable = true
                        });
                });

            modelBuilder.Entity("HostelManager.Domain.Guest", b =>
                {
                    b.HasOne("HostelManager.Domain.Room", "Room")
                        .WithMany("Guests")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HostelManager.Domain.Room", b =>
                {
                    b.HasOne("HostelManager.Domain.Hostel", "Hostel")
                        .WithMany("Rooms")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("HostelManager.Domain.Hostel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HostelManager.Domain.Room", b =>
                {
                    b.Navigation("Guests");
                });
#pragma warning restore 612, 618
        }
    }
}
