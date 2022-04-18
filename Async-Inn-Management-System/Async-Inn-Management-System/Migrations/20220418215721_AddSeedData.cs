using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn_Management_System.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Amenity_Name" },
                values: new object[,]
                {
                    { 1, "Mini bar" },
                    { 2, "ocean view" },
                    { 3, "coffee maker" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Hotel_City", "Hotel_Country", "Hotel_Name", "Hotel_Phone", "Hotel_State", "Hotel_Street_Address" },
                values: new object[,]
                {
                    { 1, "Amman", "Jordan", "Hanan Hotel", "0781234567", "Amman", "One Street" },
                    { 2, "Ajloun", "Jordan", "Lojain Hotel", "0794312333", "Ajloun", "Two Street" },
                    { 3, "Jarash", "Jordan", "Mohammad Hotel", "0778900000", "Jarash", "Three Street" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Room_Layout", "Room_Name" },
                values: new object[,]
                {
                    { 1, 2, "Seahawks Snooze" },
                    { 2, 1, "Restful Rainier" },
                    { 3, 0, "classic Snooze" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
