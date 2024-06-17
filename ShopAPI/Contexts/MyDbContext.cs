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
				}
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
				new Product { ID = 10, Name = "Uncle Bob's Organic Dried Pears", Description = "12 - 1 lb pkgs.", CategoryID = 2, Price = 100 }
			);

		base.OnModelCreating(modelBuilder);
	}


	/*protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite("connectionstring");


		base.OnConfiguring(options);
	}*/
}
