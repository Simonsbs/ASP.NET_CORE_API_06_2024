using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopAPI.Entities;

namespace ShopAPI.Contexts;

public class MyDbContext : DbContext {

    public MyDbContext(DbContextOptions<MyDbContext> options) 
		: base(options)  {        
    }

    public DbSet<Category> Categories { get; set; }
	public DbSet<Product> Products { get; set; }

	/*protected override void OnConfiguring(DbContextOptionsBuilder options) {
		options.UseSqlite("connectionstring");


		base.OnConfiguring(options);
	}*/
}
