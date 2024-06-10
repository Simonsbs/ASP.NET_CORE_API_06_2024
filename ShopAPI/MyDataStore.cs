using ShopAPI.Models;

namespace ShopAPI;

public class MyDataStore {
	public List<CategoryDTO> Categories { get; set; }

	public static MyDataStore Current { get; } = new MyDataStore();

	public MyDataStore() {
		Categories = new List<CategoryDTO> {
			new CategoryDTO { 
				ID = 1,
				Name = "Beverages",
				Description = "Soft drinks, coffees, teas, beers, and ales",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 1, Name = "Chai", Description = "10 boxes x 20 bags" },
					new ProductDTO { ID = 2, Name = "Chang", Description = "24 - 12 oz bottles" },
					new ProductDTO { ID = 3, Name = "Guaraná Fantástica", Description = "12 - 355 ml cans" },
					new ProductDTO { ID = 4, Name = "Sasquatch Ale", Description = "24 - 12 oz bottles" },
					new ProductDTO { ID = 5, Name = "Steeleye Stout", Description = "24 - 12 oz bottles" }
				}
			},
			new CategoryDTO { 
				ID = 2,
				Name = "Condiments",
				Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 6, Name = "Aniseed Syrup", Description = "12 - 550 ml bottles" },
					new ProductDTO { ID = 7, Name = "Chef Anton's Cajun Seasoning", Description = "48 - 6 oz jars" },
					new ProductDTO { ID = 8, Name = "Chef Anton's Gumbo Mix", Description = "36 boxes" },
					new ProductDTO { ID = 9, Name = "Grandma's Boysenberry Spread", Description = "12 - 8 oz jars" },
					new ProductDTO { ID = 10, Name = "Uncle Bob's Organic Dried Pears", Description = "12 - 1 lb pkgs." }
				}
			},
			new CategoryDTO { 
				ID = 3,
				Name = "Confections",
				Description = "Desserts, candies, and sweet breads",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 11, Name = "Gumbär Gummibärchen", Description = "100 - 250 g bags" },
					new ProductDTO { ID = 12, Name = "Schoggi Schokolade", Description = "100 - 100 g pieces" },
					new ProductDTO { ID = 13, Name = "Rössle Sauerkraut", Description = "25 - 825 g cans" },
					new ProductDTO { ID = 14, Name = "Thüringer Rostbratwurst", Description = "50 bags x 30 sausgs." },
					new ProductDTO { ID = 15, Name = "Nord-Ost Matjeshering", Description = "10 - 200 g glasses" }
				}
			},
			new CategoryDTO { 
				ID = 4,
				Name = "Dairy Products",
				Description = "Cheeses",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 16, Name = "Gorgonzola Telino", Description = "12 - 100 g pkgs" },
					new ProductDTO { ID = 17, Name = "Queso Cabrales", Description = "1 kg pkg" },
					new ProductDTO { ID = 18, Name = "Queso Manchego La Pastora", Description = "10 - 500 g pkgs." },
					new ProductDTO { ID = 19, Name = "Gudbrandsdalsost", Description = "10 kg pkg." },
					new ProductDTO { ID = 20, Name = "Fløtemysost", Description = "10 - 500 g pkgs." }
				}
			},
			new CategoryDTO { 
				ID = 5,
				Name = "Grains/Cereals",
				Description = "Breads, crackers, pasta, and cereal",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 21, Name = "Gustaf's Knäckebröd", Description = "24 - 500 g pkgs." },
					new ProductDTO { ID = 22, Name = "Tunnbröd", Description = "12 - 250 g pkgs." },
					new ProductDTO { ID = 23, Name = "Guaraná Fantástica", Description = "12 - 355 ml cans" },
					new ProductDTO { ID = 24, Name = "Pavlova", Description = "32 - 500 g boxes" },
					new ProductDTO { ID = 25, Name = "Alice Mutton", Description = "20 - 1 kg tins" }
				}
			},
			new CategoryDTO { 
				ID = 6,
				Name = "Meat/Poultry",
				Description = "Prepared meats",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 26, Name = "Mishi Kobe Niku", Description = "18 - 500 g pkgs." },
					new ProductDTO { ID = 27, Name = "Ikura", Description = "12 - 200 ml jars" },
					new ProductDTO { ID = 28, Name = "Queso Cabrales", Description = "1 kg pkg." },
					new ProductDTO { ID = 29, Name = "Konbu", Description = "2 kg box" },
					new ProductDTO { ID = 30, Name = "Filipino Crisps", Description = "48 - 125 g bags" }
				}
			},
			new CategoryDTO { 
				ID = 7,
				Name = "Produce",
				Description = "Dried fruit and bean curd",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 31, Name = "Tofu", Description = "40 - 100 g pkgs." },
					new ProductDTO { ID = 32, Name = "Manjimup Dried Apples", Description = "50 - 300 g pkgs." },
					new ProductDTO { ID = 33, Name = "Jack's New England Clam Chowder", Description = "12 - 12 oz cans" },
					new ProductDTO { ID = 34, Name = "Singaporean Hokkien Fried Mee", Description = "32 - 1 kg pkgs." },
					new ProductDTO { ID = 35, Name = "Ipoh Coffee", Description = "16 - 500 g tins" }
				}
			},
			new CategoryDTO { 
				ID = 8,
				Name = "Seafood",
				Description = "Seaweed and fish",
				Products = new List<ProductDTO> {
					new ProductDTO { ID = 36, Name = "Nord-Ost Matjeshering", Description = "10 - 200 g glasses" },
					new ProductDTO { ID = 37, Name = "Gorgonzola Telino", Description = "12 - 100 g pkgs" },
					new ProductDTO { ID = 38, Name = "Boston Crab Meat", Description = "24 - 4 oz tins" },
					new ProductDTO { ID = 39, Name = "Röd Kaviar", Description = "24 - 150 g jars" },
					new ProductDTO { ID = 40, Name = "Longlife Tofu", Description = "5 kg pkg." }
				}
			}
		};
	}
}
