using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn_Management_System.Migrations
{
    public partial class AddRoomsAndAmenitiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelName",
                table: "Hotels",
                newName: "Hotel_Street_Address");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Hotels",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Hotel_City",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hotel_Country",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hotel_Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hotel_Phone",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hotel_State",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amenity_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Layout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "Hotel_City",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hotel_Country",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hotel_Name",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hotel_Phone",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Hotel_State",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "Hotel_Street_Address",
                table: "Hotels",
                newName: "HotelName");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Hotels",
                newName: "HotelId");
        }
    }
}
