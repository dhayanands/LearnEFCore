using LearnEFCore.Application.Interfaces;
using LearnEFCore.Application.Services;
using LearnEFCore.Features.Course;
using LearnEFCore.Features.Quote;
using LearnEFCore.Features.Student;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace LearnEFCore.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Register dispatcher
            services.AddScoped<IDispatcher, Dispatcher>();

            // Add FluentValidation
            services.AddValidatorsFromAssemblyContaining<CreateStudentDto>();

            // Add health checks
            services.AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("DefaultConnection"), name: "Database");

            // Register features
            services.AddStudentFeature();
            services.AddQuoteFeature();
            services.AddCourseFeature();

            // Register infrastructure
            services.AddInfrastructure();

            return services;
        }
    }
}