using Microsoft.EntityFrameworkCore;
using ShopAPI.Contexts;
using ShopAPI.Entities;
using ShopAPI.Models;

namespace ShopAPI.Repositories;

public interface IProductRepository {
	Task<IEnumerable<Product>> GetProductsForCategoryAsync(int categoryID);

	Task<Product?> GetProductForCategoryAsync(int categoryID, int id);

	Task<bool> CheckCategoryExists(int categoryID);
	Task AddProductForCategoryAsync(int categoryID, Product product, bool autoSave = true);
	Task SaveChangesAsync();
	Task DeleteProduct(Product product, bool autoSave = true);
	Task<(ICollection<Product>, PagingMetadataDTO)> GetProductsAsync(string? name, string? query, int pageNumber, int pageSize);

	IQueryable<Product> GetProductsQuery();
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

	public async Task DeleteProduct(Product product, bool autoSave = true) {
		_db.Products.Remove(product);

		if (autoSave) {
			await _db.SaveChangesAsync();
		}
	}

	public async Task SaveChangesAsync() {
		await _db.SaveChangesAsync();
	}

	// NOT RECOMENDED!!!!!
	public IQueryable<Product> GetProductsQuery() {
		return _db.Products.OrderBy(p => p.Name);
	}

	public async 
		Task<(ICollection<Product>, PagingMetadataDTO)> 
		GetProductsAsync(
			string? name,
			string? query,
			int pageNumber,
			int pageSize
		) {
		IQueryable<Product> collection = _db.Products as IQueryable<Product>;

		if (!string.IsNullOrEmpty(name)) {
			name = name.Trim();
			collection = collection.Where(p => p.Name == name);
		}

		if (!string.IsNullOrEmpty(query)) {
			query = query.Trim();
			collection = collection.Where(p =>
			p.Name.Contains(query) ||
			(p.Description != null && p.Description.Contains(query)));
		}

		int count = collection.Count();

		collection = collection
			.OrderBy(p => p.Name)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize);

		var items = await collection.ToListAsync();

		PagingMetadataDTO meta = new PagingMetadataDTO {
			TotalItemCount = count,
			PageSize = pageSize,
			PageNumber = pageNumber,
			CurrentPageCount = items.Count,
		};

		

		return (items, meta);
	}
}
