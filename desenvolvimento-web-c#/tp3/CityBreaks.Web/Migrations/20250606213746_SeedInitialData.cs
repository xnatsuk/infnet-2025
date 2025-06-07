using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityBreaks.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { 1, "BR", "Brasil" },
                    { 2, "JP", "Japan" },
                    { 3, "CN", "China" },
                    { 4, "RU", "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Brasília" },
                    { 2, 1, "Rio de Janeiro" },
                    { 3, 2, "Tokyo" },
                    { 4, 2, "Osaka" },
                    { 5, 3, "Shenzhen" },
                    { 6, 3, "Macau" },
                    { 7, 4, "Moscow" },
                    { 8, 4, "Saint Petersburg" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CityId", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1, "Royal Tulip", 140.00m },
                    { 2, 2, "Hilton Rio de Janeiro Copacabana", 250.00m },
                    { 3, 3, "Aman Tokyo", 1720.00m },
                    { 4, 4, "Imperial Hotel Ōsaka", 200.00m },
                    { 5, 5, "Futian Shangri-La", 180.00m },
                    { 6, 6, "Artyzen Grand Lapa", 180.00m },
                    { 7, 7, "Hilton Moscow Leningradskaya", 160.00m },
                    { 8, 8, "Nevsky Royal Hotel", 150.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
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

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
