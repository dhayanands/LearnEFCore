using LearnEFCore.Application.Services;
using LearnEFCore.Features.Course.DTOs;
using LearnEFCore.Features.Course.Interfaces;
using LearnEFCore.Features.Course.Queries;

namespace LearnEFCore.Features.Course.Handlers
{
    public class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, CourseDto?>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<GetCourseByIdQueryHandler> _logger;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, ILogger<GetCourseByIdQueryHandler> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<CourseDto?> Handle(GetCourseByIdQuery query)
        {
            try
            {
                _logger.LogInformation("Getting course by ID {Id}", query.Id);
                var course = await _courseRepository.GetCourseByIdAsync(query.Id);
                if (course == null)
                {
                    _logger.LogWarning("Course with ID {Id} not found", query.Id);
                    return null;
                }
                var courseDto = new CourseDto
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description
                };
                return courseDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting course by ID {Id}", query.Id);
                throw;
            }
        }
    }
}