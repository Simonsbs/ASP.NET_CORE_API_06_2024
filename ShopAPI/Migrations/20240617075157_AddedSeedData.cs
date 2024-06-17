using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Soft drinks, coffees, teas, beers, and ales", "Beverages" },
                    { 2, "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "10 boxes x 20 bags", "Chai", 10f },
                    { 2, 1, "24 - 12 oz bottles", "Chang", 20f },
                    { 3, 1, "12 - 355 ml cans", "Guaraná Fantástica", 30f },
                    { 4, 1, "24 - 12 oz bottles", "Sasquatch Ale", 40f },
                    { 5, 1, "24 - 12 oz bottles", "Steeleye Stout", 50f },
                    { 6, 2, "12 - 550 ml bottles", "Aniseed Syrup", 60f },
                    { 7, 2, "48 - 6 oz jars", "Chef Anton's Cajun Seasoning", 70f },
                    { 8, 2, "36 boxes", "Chef Anton's Gumbo Mix", 80f },
                    { 9, 2, "12 - 8 oz jars", "Grandma's Boysenberry Spread", 90f },
                    { 10, 2, "12 - 1 lb pkgs.", "Uncle Bob's Organic Dried Pears", 100f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
