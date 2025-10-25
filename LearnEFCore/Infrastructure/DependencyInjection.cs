using LearnEFCore.Application.Interfaces;
using LearnEFCore.Infrastructure.Initialization;

namespace LearnEFCore.Infrastructure
{
 public static class DependencyInjection
 {
 public static IServiceCollection AddInfrastructure(this IServiceCollection services)
 {
 services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
 return services;
 }
 }
}