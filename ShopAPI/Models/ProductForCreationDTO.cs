using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models;

public class ProductForCreationDTO {
	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string? Description { get; set; }
}

