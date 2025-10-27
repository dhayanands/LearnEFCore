using CourseEntity = LearnEFCore.Domain.Entities.Course;
using LearnEFCore.Application.Services;
using LearnEFCore.Features.Course.Commands;
using LearnEFCore.Features.Course.Interfaces;

namespace LearnEFCore.Features.Course.Handlers
{
    public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, int>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CreateCourseCommandHandler> _logger;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, ILogger<CreateCourseCommandHandler> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCourseCommand command)
        {
            try
            {
                _logger.LogInformation("Creating course with title {Title}", command.CourseDto.Title);
                var course = new CourseEntity
                {
                    Title = command.CourseDto.Title,
                    Description = command.CourseDto.Description
                };
                await _courseRepository.AddCourseAsync(course);
                _logger.LogInformation("Course created with ID {Id}", course.Id);
                return course.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating course");
                throw;
            }
        }
    }
}