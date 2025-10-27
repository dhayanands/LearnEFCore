using LearnEFCore.Infrastructure.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog();

// Load environment-specific configuration
var environment = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

// Add Health Checks
builder.Services.AddHealthChecks();

// Register application services
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Validate configuration
app.ValidateConfiguration();

// Configure the HTTP request pipeline.
app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.InitializeDevelopmentDatabase();
}
else
{
    app.ApplyProductionMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Learning EF Core ;)");

app.MapHealthChecks("/health");

app.Run();
