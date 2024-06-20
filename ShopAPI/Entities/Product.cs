using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Entities;

public class Product {
	[Key]
	public int ID { get; set; }

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string? Description { get; set; }

	public float Price { get; set; }

	//[ForeignKey("CategoryID")]
	public Category? Category { get; set; }

	public int CategoryID { get; set; }
}


public class Category {
	[Key]
	public int ID { get; set; }

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string Description { get; set; }

	public List<Product> Products { get; set; } = new List<Product>();
}

public class User {
	[Key]
	public int ID { get; set; }

	[MaxLength(100)]
	public string Username { get; set; }

	[MaxLength(100)]
	public string Password { get; set; }

	[MaxLength(100)]
	public string Email { get; set; }

	[MaxLength(100)]
	public string Name { get; set; }

	public int AuthLevel { get; set; }
}