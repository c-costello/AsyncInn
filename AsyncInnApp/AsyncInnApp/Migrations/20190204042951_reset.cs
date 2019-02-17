﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInnApp.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomID = table.Column<decimal>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false),
                    RoomID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.RoomNumber, x.HotelID });
                    table.ForeignKey(
                        name: "FK_HotelRoom_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoom_Room_RoomID1",
                        column: x => x.RoomID1,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    AmenitiesID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.RoomID, x.AmenitiesID });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenitiesID",
                        column: x => x.AmenitiesID,
                        principalTable: "Amenities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Minifridge" },
                    { 2, "Kitchenette" },
                    { 3, "Jacuzzi" },
                    { 4, "Free Wifi" },
                    { 5, "Balcony" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Ocean Street", "Poseidon Inn", "555-555-5555" },
                    { 2, "123 Spring Street", "Persophene Inn", "444-555-6666" },
                    { 3, "123 Moon Street", "Artemis Inn", "777-555-8888" },
                    { 4, "123 Sun Street", "Apollo Inn", "555-999-5555" },
                    { 5, "123 Wine Street", "Diones Inn", "555-999-8888" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Honeymoon Suite" },
                    { 2, 1, "Singles Suite" },
                    { 3, 2, "Corner Suite" },
                    { 4, 2, "Family Suite" },
                    { 5, 0, "King Studio" },
                    { 6, 4, "PentHouse" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_HotelID",
                table: "HotelRoom",
                column: "HotelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID1",
                table: "HotelRoom",
                column: "RoomID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
