using LearnEFCore.Application.Interfaces;

namespace LearnEFCore.Infrastructure.Initialization
{
    public static class DatabaseInitializerExtensions
    {
        public static void InitializeDevelopmentDatabase(this IServiceProvider serviceProvider, string connectionString)
        {
            var initializer = serviceProvider.GetRequiredService<IDatabaseInitializer>();
            initializer.InitializeDevelopmentAsync(connectionString).Wait();
        }

        public static void ApplyProductionMigrations(this IServiceProvider serviceProvider)
        {
            var initializer = serviceProvider.GetRequiredService<IDatabaseInitializer>();
            initializer.ApplyMigrations();
        }
    }
}