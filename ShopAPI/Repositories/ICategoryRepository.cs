using Microsoft.EntityFrameworkCore;
using ShopAPI.Contexts;
using ShopAPI.Entities;

namespace ShopAPI.Repositories;

public interface ICategoryRepository {
	Task<IEnumerable<Category>> GetCategoriesAsync();

	Task<Category?> GetCategoryAsync(int id, bool includeProducts);

	Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryID);

}


public class CategoryRepository(MyDbContext _db) : ICategoryRepository {

	public async Task<IEnumerable<Category>> GetCategoriesAsync() {
		return await _db.Categories.OrderBy(c => c.Name).ToListAsync();
	}

	public async Task<Category?> GetCategoryAsync(int id, bool includeProducts) {
		if (includeProducts) {
			return await _db.Categories
				.Include(c => c.Products)
				.Where(c => c.ID == id)
				.FirstOrDefaultAsync();
		}

		return await _db.Categories
				.Where(c => c.ID == id)
				.FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryID) {
		return await _db.Products
			.Where(p => p.CategoryID == categoryID)
			.ToListAsync();
	}
}