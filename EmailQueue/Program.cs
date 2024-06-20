using EmailQueue.Contexts;
using EmailQueue.Repositories;
using EmailQueue.Services;
using Microsoft.EntityFrameworkCore;

internal class Program {
	private static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddDbContext<MainContext>(o =>
			o.UseSqlite(
				builder.Configuration["ConnectionStrings:SQLITE_CONNECTION"]
			)
		);

		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		builder.Services.AddScoped<IEmailMessageRepository, EmailMessageRepository>();

		builder.Services.AddTransient<IMailService, MailTrapService>();

		builder.Services.AddHostedService<EmailBackgroundService>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment()) {
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}