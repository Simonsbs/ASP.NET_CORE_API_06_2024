using EmailQueue.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailQueue.Contexts;

public class MainContext : DbContext {
	public MainContext(DbContextOptions options) 
		: base(options) {
	}

	public DbSet<EmailMessage> EmailMessages { get; set; }
}
