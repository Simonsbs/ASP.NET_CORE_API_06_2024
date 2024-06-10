using ShopAPI.Models;

namespace ShopAPI;

public class MyDataStore {
	private List<CategoryDTO> Categories { get; set; }


	public MyDataStore() {
		Categories = new List<CategoryDTO> {
			new CategoryDTO { ID = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
			new CategoryDTO { ID = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
			new CategoryDTO { ID = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads" },
			new CategoryDTO { ID = 4, Name = "Dairy Products", Description = "Cheeses" },
			new CategoryDTO { ID = 5, Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
			new CategoryDTO { ID = 6, Name = "Meat/Poultry", Description = "Prepared meats" },
			new CategoryDTO { ID = 7, Name = "Produce", Description = "Dried fruit and bean curd" },
			new CategoryDTO { ID = 8, Name = "Seafood", Description = "Seaweed and fish" }
		};
	}
}
