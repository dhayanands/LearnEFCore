using LearnEFCore.Application.Interfaces;

namespace LearnEFCore.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
   public static void ValidateConfiguration(this WebApplication app)
   {
   var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
  if (string.IsNullOrEmpty(connectionString))
      {
      throw new InvalidOperationException("Database connection string 'DefaultConnection' is not configured.");
        }
        }

  public static void InitializeDevelopmentDatabase(this WebApplication app)
   {
   using var scope = app.Services.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
 var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
        initializer.InitializeDevelopmentAsync(connectionString!).Wait();
    }

    public static void ApplyProductionMigrations(this WebApplication app)
   {
   using var scope = app.Services.CreateScope();
   var initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
 initializer.ApplyMigrations();
   }
    }
}