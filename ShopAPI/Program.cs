
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShopAPI.Contexts;
using ShopAPI.Services;

namespace ShopAPI;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Warning()
#if DEBUG
			.WriteTo.Console()
#endif
			.WriteTo.File("logs/mylog.txt", rollingInterval: RollingInterval.Day)
			.CreateLogger();

		builder.Host.UseSerilog();

		// Add services to the container.
		builder.Services.AddControllers(options => {
			//options.ReturnHttpNotAcceptable = true;
		})
			.AddNewtonsoftJson()
			.AddXmlDataContractSerializerFormatters();


		builder.Services.AddProblemDetails(options => {
			options.CustomizeProblemDetails = ctx => {
				ctx.
					ProblemDetails.
					Extensions.
					Add("Example", "Simon Was here");

				ctx.
					ProblemDetails.
					Extensions.
					Add("Machine", Environment.MachineName);
			};
		});

		//builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.
			AddSingleton<FileExtensionContentTypeProvider>();


#if DEBUG
		builder.Services.AddTransient<IMailService, LocalMailService>();
#else
		builder.Services.AddTransient<IMailService, ProductionMailService>();
#endif

		builder.Services.AddDbContext<MyDbContext>(options => 
			options.UseSqlite("Data Source=MyShop.db"));

		var app = builder.Build();

		if (!app.Environment.IsDevelopment()) {
			app.UseExceptionHandler();
		}

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
