using LearnEFCore.Application.Interfaces;
using LearnEFCore.Infrastructure.Data;
using LearnEFCore.Infrastructure.Repositories;
using LearnEFCore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment-specific configuration
var environment = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IQuoteService, QuoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Reset the database in development
    Console.WriteLine("Resetting database...");
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
    Console.WriteLine("Database reset complete.");

    // Seed the database with test data
    DataSeeder.Seed(ctx);
}
else
{
    // Apply migrations in production
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    Console.WriteLine("Applying migrations...");
    ctx.Database.Migrate();
    Console.WriteLine("Migrations applied.");
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Learning EF Core ;)");

app.Run();
