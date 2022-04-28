using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn_Management_System.Migrations
{
    public partial class UpdateRoomAmenitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmentityId",
                table: "RoomAmenities",
                newName: "AmenitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "RoomAmenities",
                newName: "AmentityId");
        }
    }
}
