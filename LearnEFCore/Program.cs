using LearnEFCore.Application.Interfaces;
using LearnEFCore.Infrastructure.Data;
using LearnEFCore.Infrastructure.Repositories;
using LearnEFCore.Infrastructure.Services;
using LearnEFCore.Infrastructure.Initialization;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog();

// Load environment-specific configuration
var environment = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

var app = builder.Build();

// Validate configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string 'DefaultConnection' is not configured.");
}

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
 using var scope = app.Services.CreateScope();
 var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

 // Ensure the database exists and reset it in development
 await initializer.InitializeDevelopmentAsync(connectionString!);
}
else
{
 using var scope = app.Services.CreateScope();
 var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

 // Apply migrations in production
 initializer.ApplyMigrations();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Learning EF Core ;)");

app.Run();
