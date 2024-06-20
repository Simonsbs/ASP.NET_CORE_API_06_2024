
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using ShopAPI.Contexts;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Information()
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

		if (builder.Configuration["Database:Source"] == "MS-SQL") {
			builder.Services.AddDbContext<MyDbContext>(options =>
				options.UseSqlServer(builder.Configuration["ConnectionStrings:MS-SQL"]));
		} else { // is SQLITE
			builder.Services.AddDbContext<MyDbContext>(options =>
				options.UseSqlite(builder.Configuration["ConnectionStrings:Main"]));
		}


		builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
		builder.Services.AddScoped<IProductRepository, ProductRepository>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();

		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		builder.Services.AddAuthentication("Bearer")
			.AddJwtBearer(o => {
				o.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["Authentication:Issuer"],

					ValidateAudience = true,
					ValidAudience = builder.Configuration["Authentication:Audience"],

					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Convert
						.FromBase64String(builder.Configuration["Authentication:MyKey"])
					)
				};
			});

		builder.Services.AddAuthorization(o => {
			o.AddPolicy("IsSimon", policy => {
				policy.RequireAuthenticatedUser();
				policy.RequireClaim("auth_level", "9");
			});
		});


		var app = builder.Build();

		using (var scope = app.Services.CreateScope()) {
			var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
			context.Database.Migrate();
		}

		if (!app.Environment.IsDevelopment()) {
			app.UseExceptionHandler();
		}

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment()) {
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthentication();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
