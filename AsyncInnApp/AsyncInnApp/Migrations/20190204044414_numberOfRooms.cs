using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInnApp.Migrations
{
    public partial class numberOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Room",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Room");
        }
    }
}
