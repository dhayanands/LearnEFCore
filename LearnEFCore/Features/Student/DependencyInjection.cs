using LearnEFCore.Application.Services;
using LearnEFCore.Features.Student.Commands;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Handlers;
using LearnEFCore.Features.Student.Infrastructure;
using LearnEFCore.Features.Student.Interfaces;
using LearnEFCore.Features.Student.Queries;
using LearnEFCore.Features.Student.Services;

namespace LearnEFCore.Features.Student
{
    public static class StudentFeatureExtensions
    {
        public static IServiceCollection AddStudentFeature(this IServiceCollection services)
        {
            // Register Student feature services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            // Register command and query handlers
            services.AddScoped<ICommandHandler<CreateStudentCommand, int>, CreateStudentCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateStudentCommand>, UpdateStudentCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteStudentCommand>, DeleteStudentCommandHandler>();
            services.AddScoped<IQueryHandler<GetStudentsQuery, List<StudentDto>>, GetStudentsQueryHandler>();
            services.AddScoped<IQueryHandler<GetStudentByIdQuery, StudentDto?>, GetStudentByIdQueryHandler>();

            return services;
        }
    }
}