using LearnEFCore.Application.Services;
using LearnEFCore.Features.Course.Commands;
using LearnEFCore.Features.Course.DTOs;
using LearnEFCore.Features.Course.Handlers;
using LearnEFCore.Features.Course.Infrastructure;
using LearnEFCore.Features.Course.Interfaces;
using LearnEFCore.Features.Course.Queries;

namespace LearnEFCore.Features.Course
{
    public static class CourseFeatureExtensions
    {
        public static IServiceCollection AddCourseFeature(this IServiceCollection services)
        {
            // Register Course feature services
            services.AddScoped<ICourseRepository, CourseRepository>();

            // Register command and query handlers
            services.AddScoped<ICommandHandler<CreateCourseCommand, int>, CreateCourseCommandHandler>();
            services.AddScoped<IQueryHandler<GetCoursesQuery, List<CourseDto>>, GetCoursesQueryHandler>();
            services.AddScoped<IQueryHandler<GetCourseByIdQuery, CourseDto?>, GetCourseByIdQueryHandler>();

            return services;
        }
    }
}