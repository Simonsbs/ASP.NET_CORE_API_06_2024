using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class MoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Milk, cheese, yogurt, and butter", "Dairy" },
                    { 4, "Breads, pastries, and cakes", "Bakery" },
                    { 5, "Fruits and vegetables", "Produce" },
                    { 6, "Beef, chicken, pork, and seafood", "Meat" },
                    { 7, "Frozen meals, ice cream, and frozen vegetables", "Frozen Foods" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 11, 1, "24 - 12 oz cans", "Coca-Cola", 25f },
                    { 12, 1, "24 - 12 oz cans", "Pepsi", 25f },
                    { 13, 1, "100g jar", "Nescafe Coffee", 15f },
                    { 14, 1, "50 tea bags", "Green Tea", 12f },
                    { 15, 1, "24 - 12 oz bottles", "Budweiser", 30f },
                    { 16, 1, "24 - 12 oz bottles", "Heineken", 35f },
                    { 17, 2, "20 oz bottle", "Ketchup", 5f },
                    { 18, 2, "32 oz jar", "Mayonnaise", 8f },
                    { 19, 2, "8 oz bottle", "Mustard", 4f },
                    { 20, 2, "16 oz bottle", "Soy Sauce", 6f },
                    { 39, 1, "24 - 12 oz cans", "Coca-Cola Zero", 25f },
                    { 40, 1, "24 - 12 oz cans", "Sprite", 25f },
                    { 41, 1, "50 capsules", "Nespresso Coffee", 30f },
                    { 42, 1, "100 tea bags", "Black Tea", 10f },
                    { 43, 1, "24 - 12 oz bottles", "Corona", 35f },
                    { 44, 1, "24 - 12 oz bottles", "Bud Light", 30f },
                    { 45, 2, "18 oz bottle", "Barbecue Sauce", 4f },
                    { 46, 2, "16 oz jar", "Salsa", 5f },
                    { 47, 2, "12 oz bottle", "Honey Mustard", 4f },
                    { 48, 2, "32 oz bottle", "Vinegar", 3f },
                    { 21, 3, "1 gallon", "Milk", 3f },
                    { 22, 3, "8 oz block", "Cheese", 4f },
                    { 23, 3, "6-pack", "Yogurt", 6f },
                    { 24, 3, "16 oz tub", "Butter", 5f },
                    { 25, 4, "20 oz loaf", "White Bread", 2f },
                    { 26, 4, "6-pack", "Croissant", 4f },
                    { 27, 4, "8-inch", "Chocolate Cake", 10f },
                    { 28, 5, "1 lb", "Apple", 1f },
                    { 29, 5, "1 lb", "Banana", 0.5f },
                    { 30, 5, "1 lb", "Orange", 0.75f },
                    { 31, 5, "1 lb", "Strawberries", 2f },
                    { 32, 6, "1 lb", "Beef", 8f },
                    { 33, 6, "1 lb", "Chicken", 6f },
                    { 34, 6, "1 lb", "Pork", 7f },
                    { 35, 6, "8 oz fillet", "Salmon", 12f },
                    { 36, 7, "12-inch", "Frozen Pizza", 8f },
                    { 37, 7, "1 pint", "Ice Cream", 5f },
                    { 38, 7, "16 oz bag", "Frozen Vegetables", 3f },
                    { 49, 3, "1 quart", "Almond Milk", 4f },
                    { 50, 3, "32 oz tub", "Greek Yogurt", 6f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
