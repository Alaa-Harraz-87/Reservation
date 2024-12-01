﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.InfraStructure;

#nullable disable

namespace Reservation.InfraStructure.Migrations
{
    [DbContext(typeof(ReservationContext))]
    [Migration("20241201164402_userAnaltics_view")]
    partial class userAnaltics_view
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Reservation.Core.Entities.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 20,
                            Name = "Bus 1"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 20,
                            Name = "Bus 2"
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TripRouteId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("TripRouteId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("SeatNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusId = 1,
                            SeatNo = "A1",
                            Status = 0
                        },
                        new
                        {
                            Id = 21,
                            BusId = 2,
                            SeatNo = "A1",
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            BusId = 1,
                            SeatNo = "A2",
                            Status = 0
                        },
                        new
                        {
                            Id = 22,
                            BusId = 2,
                            SeatNo = "A2",
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            BusId = 1,
                            SeatNo = "A3",
                            Status = 0
                        },
                        new
                        {
                            Id = 23,
                            BusId = 2,
                            SeatNo = "A3",
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            BusId = 1,
                            SeatNo = "A4",
                            Status = 0
                        },
                        new
                        {
                            Id = 24,
                            BusId = 2,
                            SeatNo = "A4",
                            Status = 0
                        },
                        new
                        {
                            Id = 5,
                            BusId = 1,
                            SeatNo = "A5",
                            Status = 0
                        },
                        new
                        {
                            Id = 25,
                            BusId = 2,
                            SeatNo = "A5",
                            Status = 0
                        },
                        new
                        {
                            Id = 6,
                            BusId = 1,
                            SeatNo = "A6",
                            Status = 0
                        },
                        new
                        {
                            Id = 26,
                            BusId = 2,
                            SeatNo = "A6",
                            Status = 0
                        },
                        new
                        {
                            Id = 7,
                            BusId = 1,
                            SeatNo = "A7",
                            Status = 0
                        },
                        new
                        {
                            Id = 27,
                            BusId = 2,
                            SeatNo = "A7",
                            Status = 0
                        },
                        new
                        {
                            Id = 8,
                            BusId = 1,
                            SeatNo = "A8",
                            Status = 0
                        },
                        new
                        {
                            Id = 28,
                            BusId = 2,
                            SeatNo = "A8",
                            Status = 0
                        },
                        new
                        {
                            Id = 9,
                            BusId = 1,
                            SeatNo = "A9",
                            Status = 0
                        },
                        new
                        {
                            Id = 29,
                            BusId = 2,
                            SeatNo = "A9",
                            Status = 0
                        },
                        new
                        {
                            Id = 10,
                            BusId = 1,
                            SeatNo = "A10",
                            Status = 0
                        },
                        new
                        {
                            Id = 30,
                            BusId = 2,
                            SeatNo = "A10",
                            Status = 0
                        },
                        new
                        {
                            Id = 11,
                            BusId = 1,
                            SeatNo = "A11",
                            Status = 0
                        },
                        new
                        {
                            Id = 31,
                            BusId = 2,
                            SeatNo = "A11",
                            Status = 0
                        },
                        new
                        {
                            Id = 12,
                            BusId = 1,
                            SeatNo = "A12",
                            Status = 0
                        },
                        new
                        {
                            Id = 32,
                            BusId = 2,
                            SeatNo = "A12",
                            Status = 0
                        },
                        new
                        {
                            Id = 13,
                            BusId = 1,
                            SeatNo = "A13",
                            Status = 0
                        },
                        new
                        {
                            Id = 33,
                            BusId = 2,
                            SeatNo = "A13",
                            Status = 0
                        },
                        new
                        {
                            Id = 14,
                            BusId = 1,
                            SeatNo = "A14",
                            Status = 0
                        },
                        new
                        {
                            Id = 34,
                            BusId = 2,
                            SeatNo = "A14",
                            Status = 0
                        },
                        new
                        {
                            Id = 15,
                            BusId = 1,
                            SeatNo = "A15",
                            Status = 0
                        },
                        new
                        {
                            Id = 35,
                            BusId = 2,
                            SeatNo = "A15",
                            Status = 0
                        },
                        new
                        {
                            Id = 16,
                            BusId = 1,
                            SeatNo = "A16",
                            Status = 0
                        },
                        new
                        {
                            Id = 36,
                            BusId = 2,
                            SeatNo = "A16",
                            Status = 0
                        },
                        new
                        {
                            Id = 17,
                            BusId = 1,
                            SeatNo = "A17",
                            Status = 0
                        },
                        new
                        {
                            Id = 37,
                            BusId = 2,
                            SeatNo = "A17",
                            Status = 0
                        },
                        new
                        {
                            Id = 18,
                            BusId = 1,
                            SeatNo = "A18",
                            Status = 0
                        },
                        new
                        {
                            Id = 38,
                            BusId = 2,
                            SeatNo = "A18",
                            Status = 0
                        },
                        new
                        {
                            Id = 19,
                            BusId = 1,
                            SeatNo = "A19",
                            Status = 0
                        },
                        new
                        {
                            Id = 39,
                            BusId = 2,
                            SeatNo = "A19",
                            Status = 0
                        },
                        new
                        {
                            Id = 20,
                            BusId = 1,
                            SeatNo = "A20",
                            Status = 0
                        },
                        new
                        {
                            Id = 40,
                            BusId = 2,
                            SeatNo = "A20",
                            Status = 0
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Reservation.Core.Entities.TripRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PickUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TripRoutes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusId = 1,
                            Destination = "Aswan",
                            Distance = 150m,
                            Name = "Cairo-Aswan",
                            PickUp = "Cairo",
                            Price = 10m,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            BusId = 2,
                            Destination = "Alexandria ",
                            Distance = 90m,
                            Name = "Cairo-Alexandria ",
                            PickUp = "Cairo",
                            Price = 10m,
                            Type = 0
                        });
                });

            modelBuilder.Entity("Reservation.Core.Entities.Views.V_UserAnalytics", b =>
                {
                    b.Property<int>("DaysBetweenTrips")
                        .HasColumnType("int")
                        .HasColumnName("DaysBetweenTrips");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Destination");

                    b.Property<string>("Pickup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Pickup");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserEmail");

                    b.ToView("V_UserAnalytics");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Reservation", b =>
                {
                    b.HasOne("Reservation.Core.Entities.TripRoute", "TripRoute")
                        .WithMany()
                        .HasForeignKey("TripRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TripRoute");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Seat", b =>
                {
                    b.HasOne("Reservation.Core.Entities.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Ticket", b =>
                {
                    b.HasOne("Reservation.Core.Entities.Reservation", "Reservation")
                        .WithMany("Tickets")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservation.Core.Entities.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Reservation.Core.Entities.Reservation", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
