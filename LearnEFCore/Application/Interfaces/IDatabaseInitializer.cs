using System.Threading.Tasks;

namespace LearnEFCore.Application.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task InitializeDevelopmentAsync(string connectionString);
        void ApplyMigrations();
    }
}