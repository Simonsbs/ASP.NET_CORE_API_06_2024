using Microsoft.EntityFrameworkCore;
using ShopAPI.Contexts;
using ShopAPI.Entities;

namespace ShopAPI.Repositories;

public interface IProductRepository {
	Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryID);

	Task<Product?> GetProductForCategoryAsync(int categoryID, int id);

	Task<bool> CheckCategoryExists(int categoryID);
	Task AddProductForCategoryAsync(int categoryID, Product product, bool autoSave = true);
	Task SaveChangesAsync();
}


public class ProductRepository(MyDbContext _db) : IProductRepository {
	public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryID) {
		return await _db.Products
			.Where(p => p.CategoryID == categoryID)
			.ToListAsync();
	}

	public async Task<Product?> GetProductForCategoryAsync(int categoryID, int id) {
		return await _db.Products
			.FirstOrDefaultAsync(p => p.ID == id && p.CategoryID == categoryID);
	}

	public async Task<bool> CheckCategoryExists(int categoryID) {
		return await _db.Categories.AnyAsync(c => c.ID == categoryID);
	}

	public async Task AddProductForCategoryAsync(int categoryID, Product product, bool autoSave = true) {
		Category? category = await _db.Categories.FirstOrDefaultAsync(c => c.ID == categoryID);
		if (category != null) {
			category.Products.Add(product);

			if (autoSave) {
				await _db.SaveChangesAsync();
			}
		}		
	}

	public async Task SaveChangesAsync() {
		await _db.SaveChangesAsync();
	}
}
