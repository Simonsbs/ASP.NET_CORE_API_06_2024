namespace ShopAPI.Models;

public class CategoryDTO {
	public int ID { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

    public List<ProductDTO> Products { get; set; }
}