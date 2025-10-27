using LearnEFCore.Application.Services;
using LearnEFCore.Features.Course.DTOs;
using LearnEFCore.Features.Course.Interfaces;
using LearnEFCore.Features.Course.Queries;

namespace LearnEFCore.Features.Course.Handlers
{
    public class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseDto>> Handle(GetCoursesQuery query)
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description
            }).ToList();
        }
    }
}