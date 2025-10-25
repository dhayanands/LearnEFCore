using LearnEFCore.Application.Interfaces;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LearnEFCore.Infrastructure.Initialization
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DatabaseInitializer> _logger;

        public DatabaseInitializer(AppDbContext context, ILogger<DatabaseInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitializeDevelopmentAsync(string connectionString)
        {
            EnsureDatabaseExists(connectionString);

            _logger.LogInformation("Resetting database...");
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _logger.LogInformation("Database reset complete.");

            await DataSeeder.SeedAsync(_context, _logger);
        }

        public void ApplyMigrations()
        {
            _logger.LogInformation("Applying migrations...");
            _context.Database.Migrate();
            _logger.LogInformation("Migrations applied.");
        }

        private void EnsureDatabaseExists(string connectionString)
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            var databaseName = builder.Database;

            // Connect to the default "postgres" database to check for the target database
            builder.Database = "postgres";

            using var connection = new NpgsqlConnection(builder.ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{databaseName}'";
            var databaseExists = command.ExecuteScalar() != null;

            if (!databaseExists)
            {
                _logger.LogInformation($"Database '{databaseName}' does not exist. Creating...");
                command.CommandText = $"CREATE DATABASE \"{databaseName}\"";
                command.ExecuteNonQuery();
                _logger.LogInformation($"Database '{databaseName}' created successfully.");
            }
        }
    }
}