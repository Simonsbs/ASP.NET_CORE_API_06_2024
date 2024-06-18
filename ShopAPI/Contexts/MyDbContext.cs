using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopAPI.Entities;
using ShopAPI.Models;

namespace ShopAPI.Contexts;

public class MyDbContext : DbContext {

	public MyDbContext(DbContextOptions<MyDbContext> options)
		: base(options) {
	}

	public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Category>()
			.HasData(
				new Category() {
					ID = 1,
					Name = "Beverages",
					Description = "Soft drinks, coffees, teas, beers, and ales",
				},
				new Category() {
					ID = 2,
					Name = "Condiments",
					Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
				},
				new Category() { ID = 3, Name = "Dairy", Description = "Milk, cheese, yogurt, and butter" },
				new Category() { ID = 4, Name = "Bakery", Description = "Breads, pastries, and cakes" },
				new Category() { ID = 5, Name = "Produce", Description = "Fruits and vegetables" },
				new Category() { ID = 6, Name = "Meat", Description = "Beef, chicken, pork, and seafood" },
				new Category() { ID = 7, Name = "Frozen Foods", Description = "Frozen meals, ice cream, and frozen vegetables" }
			);

		modelBuilder.Entity<Product>()
			.HasData(
				new Product { ID = 1, Name = "Chai", Description = "10 boxes x 20 bags", CategoryID = 1, Price = 10 },
				new Product { ID = 2, Name = "Chang", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 20 },
				new Product { ID = 3, Name = "Guaraná Fantástica", Description = "12 - 355 ml cans", CategoryID = 1, Price = 30 },
				new Product { ID = 4, Name = "Sasquatch Ale", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 40 },
				new Product { ID = 5, Name = "Steeleye Stout", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 50 },
				new Product { ID = 6, Name = "Aniseed Syrup", Description = "12 - 550 ml bottles", CategoryID = 2, Price = 60 },
				new Product { ID = 7, Name = "Chef Anton's Cajun Seasoning", Description = "48 - 6 oz jars", CategoryID = 2, Price = 70 },
				new Product { ID = 8, Name = "Chef Anton's Gumbo Mix", Description = "36 boxes", CategoryID = 2, Price = 80 },
				new Product { ID = 9, Name = "Grandma's Boysenberry Spread", Description = "12 - 8 oz jars", CategoryID = 2, Price = 90 },
				new Product { ID = 10, Name = "Uncle Bob's Organic Dried Pears", Description = "12 - 1 lb pkgs.", CategoryID = 2, Price = 100 },
				new Product { ID = 11, Name = "Coca-Cola", Description = "24 - 12 oz cans", CategoryID = 1, Price = 25 },
				new Product { ID = 12, Name = "Pepsi", Description = "24 - 12 oz cans", CategoryID = 1, Price = 25 },
				new Product { ID = 13, Name = "Nescafe Coffee", Description = "100g jar", CategoryID = 1, Price = 15 },
				new Product { ID = 14, Name = "Green Tea", Description = "50 tea bags", CategoryID = 1, Price = 12 },
				new Product { ID = 15, Name = "Budweiser", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 30 },
				new Product { ID = 16, Name = "Heineken", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 35 },
				new Product { ID = 17, Name = "Ketchup", Description = "20 oz bottle", CategoryID = 2, Price = 5 },
				new Product { ID = 18, Name = "Mayonnaise", Description = "32 oz jar", CategoryID = 2, Price = 8 },
				new Product { ID = 19, Name = "Mustard", Description = "8 oz bottle", CategoryID = 2, Price = 4 },
				new Product { ID = 20, Name = "Soy Sauce", Description = "16 oz bottle", CategoryID = 2, Price = 6 },
				new Product { ID = 21, Name = "Milk", Description = "1 gallon", CategoryID = 3, Price = 3 },
				new Product { ID = 22, Name = "Cheese", Description = "8 oz block", CategoryID = 3, Price = 4 },
				new Product { ID = 23, Name = "Yogurt", Description = "6-pack", CategoryID = 3, Price = 6 },
				new Product { ID = 24, Name = "Butter", Description = "16 oz tub", CategoryID = 3, Price = 5 },
				new Product { ID = 25, Name = "White Bread", Description = "20 oz loaf", CategoryID = 4, Price = 2 },
				new Product { ID = 26, Name = "Croissant", Description = "6-pack", CategoryID = 4, Price = 4 },
				new Product { ID = 27, Name = "Chocolate Cake", Description = "8-inch", CategoryID = 4, Price = 10 },
				new Product { ID = 28, Name = "Apple", Description = "1 lb", CategoryID = 5, Price = 1 },
				new Product { ID = 29, Name = "Banana", Description = "1 lb", CategoryID = 5, Price = 0.5 },
				new Product { ID = 30, Name = "Orange", Description = "1 lb", CategoryID = 5, Price = 0.75 },
				new Product { ID = 31, Name = "Strawberries", Description = "1 lb", CategoryID = 5, Price = 2 },
				new Product { ID = 32, Name = "Beef", Description = "1 lb", CategoryID = 6, Price = 8 },
				new Product { ID = 33, Name = "Chicken", Description = "1 lb", CategoryID = 6, Price = 6 },
				new Product { ID = 34, Name = "Pork", Description = "1 lb", CategoryID = 6, Price = 7 },
				new Product { ID = 35, Name = "Salmon", Description = "8 oz fillet", CategoryID = 6, Price = 12 },
				new Product { ID = 36, Name = "Frozen Pizza", Description = "12-inch", CategoryID = 7, Price = 8 },
				new Product { ID = 37, Name = "Ice Cream", Description = "1 pint", CategoryID = 7, Price = 5 },
				new Product { ID = 38, Name = "Frozen Vegetables", Description = "16 oz bag", CategoryID = 7, Price = 3 },
				new Product { ID = 39, Name = "Coca-Cola Zero", Description = "24 - 12 oz cans", CategoryID = 1, Price = 25 },
				new Product { ID = 40, Name = "Sprite", Description = "24 - 12 oz cans", CategoryID = 1, Price = 25 },
				new Product { ID = 41, Name = "Nespresso Coffee", Description = "50 capsules", CategoryID = 1, Price = 30 },
				new Product { ID = 42, Name = "Black Tea", Description = "100 tea bags", CategoryID = 1, Price = 10 },
				new Product { ID = 43, Name = "Corona", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 35 },
				new Product { ID = 44, Name = "Bud Light", Description = "24 - 12 oz bottles", CategoryID = 1, Price = 30 },
				new Product { ID = 45, Name = "Barbecue Sauce", Description = "18 oz bottle", CategoryID = 2, Price = 4 },
				new Product { ID = 46, Name = "Salsa", Description = "16 oz jar", CategoryID = 2, Price = 5 },
				new Product { ID = 47, Name = "Honey Mustard", Description = "12 oz bottle", CategoryID = 2, Price = 4 },
				new Product { ID = 48, Name = "Vinegar", Description = "32 oz bottle", CategoryID = 2, Price = 3 },
				new Product { ID = 49, Name = "Almond Milk", Description = "1 quart", CategoryID = 3, Price = 4 },
				new Product { ID = 50, Name = "Greek Yogurt", Description = "32 oz tub", CategoryID = 3, Price = 6 }
			);

		base.OnModelCreating(modelBuilder);
	}


	/*protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite("connectionstring");


		base.OnConfiguring(options);
	}*/
}
