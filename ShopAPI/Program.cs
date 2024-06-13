
using Microsoft.AspNetCore.StaticFiles;
using Serilog;

namespace ShopAPI;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Warning()
#if DEBUG
			.WriteTo.Console()
#endif
			.WriteTo.File("logs/mylog.txt", rollingInterval: RollingInterval.Minute)
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
