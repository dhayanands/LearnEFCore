using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Course.DTOs;

namespace LearnEFCore.Features.Course.Queries
{
    public class GetCourseByIdQuery : Query<CourseDto?>
    {
        public int Id { get; set; }
    }
}