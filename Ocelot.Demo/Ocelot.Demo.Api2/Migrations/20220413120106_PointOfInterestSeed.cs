using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ocelot.Demo.Api2.Migrations
{
    public partial class PointOfInterestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "City known for CN Tower", "Toronto" },
                    { 2, "City known for Bollywood", "Mumbai" },
                    { 3, "City known for rich culture and diversity", "Delhi" },
                    { 4, "Fashion and Financial capital", "New York" },
                    { 5, "Fashion capital", "Paris" }
                });

            migrationBuilder.InsertData(
                table: "PointOfInterests",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "An incredible tower", "CN Tower" },
                    { 2, 1, "A city surrounded by the lake", "Lake Ontario" },
                    { 3, 2, "An iconic hotel and pride of India", "Taj Hotel" },
                    { 4, 3, "A historic monument", "Qutub Minar" },
                    { 5, 4, "Iconic towers to replace twin towers", "One World" },
                    { 6, 4, "An extraordinary Art Museum", "Guggenheim Museum" },
                    { 7, 5, "An iconic French tower", "Eifel Tower" },
                    { 8, 5, "Attest the greatness of many civilizations", "The Louvre" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PointOfInterests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
