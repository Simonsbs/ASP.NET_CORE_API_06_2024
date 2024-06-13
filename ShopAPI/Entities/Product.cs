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
}


public class Category {
	[Key]
	public int ID { get; set; }

	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string Description { get; set; }
}