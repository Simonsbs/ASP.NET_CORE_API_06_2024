using Microsoft.EntityFrameworkCore;
using ShopAPI.Contexts;
using ShopAPI.Entities;

namespace ShopAPI.Repositories;

public interface IUserRepository {
	Task<User?> AuthenticateUserAsync(string username, string password);
}

class UserRepository(MyDbContext _db) : IUserRepository {
	public async Task<User?> AuthenticateUserAsync(string username, string password) {
		return await _db.Users
			.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
	}
}