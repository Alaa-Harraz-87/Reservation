using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.InfraStructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripRouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_TripRoutes_TripRouteId",
                        column: x => x.TripRouteId,
                        principalTable: "TripRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 20, "Bus 1" },
                    { 2, 20, "Bus 2" }
                });

            migrationBuilder.InsertData(
                table: "TripRoutes",
                columns: new[] { "Id", "BusId", "Destination", "Distance", "Name", "PickUp", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Aswan", 150m, "Cairo-Aswan", "Cairo", 10m, 1 },
                    { 2, 2, "Alexandria ", 90m, "Cairo-Alexandria ", "Cairo", 10m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BusId", "SeatNo", "Status" },
                values: new object[,]
                {
                    { 1, 1, "A1", 0 },
                    { 2, 1, "A2", 0 },
                    { 3, 1, "A3", 0 },
                    { 4, 1, "A4", 0 },
                    { 5, 1, "A5", 0 },
                    { 6, 1, "A6", 0 },
                    { 7, 1, "A7", 0 },
                    { 8, 1, "A8", 0 },
                    { 9, 1, "A9", 0 },
                    { 10, 1, "A10", 0 },
                    { 11, 1, "A11", 0 },
                    { 12, 1, "A12", 0 },
                    { 13, 1, "A13", 0 },
                    { 14, 1, "A14", 0 },
                    { 15, 1, "A15", 0 },
                    { 16, 1, "A16", 0 },
                    { 17, 1, "A17", 0 },
                    { 18, 1, "A18", 0 },
                    { 19, 1, "A19", 0 },
                    { 20, 1, "A20", 0 },
                    { 21, 2, "A1", 0 },
                    { 22, 2, "A2", 0 },
                    { 23, 2, "A3", 0 },
                    { 24, 2, "A4", 0 },
                    { 25, 2, "A5", 0 },
                    { 26, 2, "A6", 0 },
                    { 27, 2, "A7", 0 },
                    { 28, 2, "A8", 0 },
                    { 29, 2, "A9", 0 },
                    { 30, 2, "A10", 0 },
                    { 31, 2, "A11", 0 },
                    { 32, 2, "A12", 0 },
                    { 33, 2, "A13", 0 },
                    { 34, 2, "A14", 0 },
                    { 35, 2, "A15", 0 },
                    { 36, 2, "A16", 0 },
                    { 37, 2, "A17", 0 },
                    { 38, 2, "A18", 0 },
                    { 39, 2, "A19", 0 },
                    { 40, 2, "A20", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripRouteId",
                table: "Reservations",
                column: "TripRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BusId",
                table: "Seats",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "TripRoutes");

            migrationBuilder.DropTable(
                name: "Buses");
        }
    }
}
