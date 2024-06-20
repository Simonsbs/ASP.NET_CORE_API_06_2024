using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Soft drinks, coffees, teas, beers, and ales", "Beverages" },
                    { 2, "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments" },
                    { 3, "Milk, cheese, yogurt, and butter", "Dairy" },
                    { 4, "Breads, pastries, and cakes", "Bakery" },
                    { 5, "Fruits and vegetables", "Produce" },
                    { 6, "Beef, chicken, pork, and seafood", "Meat" },
                    { 7, "Frozen meals, ice cream, and frozen vegetables", "Frozen Foods" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "AuthLevel", "Email", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 9, "Simon@Simon.com", "Simon Stirling", "1234", "Simon" },
                    { 2, 2, "Bob@bob.com", "Bob Smith", "1234", "Bob" }
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
                    { 10, 2, "12 - 1 lb pkgs.", "Uncle Bob's Organic Dried Pears", 100f },
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
                    { 49, 3, "1 quart", "Almond Milk", 4f },
                    { 50, 3, "32 oz tub", "Greek Yogurt", 6f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
