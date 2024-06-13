using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models;

public class ProductForUpdateDTO {
	[Required(ErrorMessage = "Name is required when updating")]
	[MaxLength(20)]
	public string Name { get; set; }

	[MaxLength(200)]
	public string? Description { get; set; }
}