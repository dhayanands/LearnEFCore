using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Course.DTOs;

namespace LearnEFCore.Features.Course.Queries
{
    public class GetCoursesQuery : IQuery<List<CourseDto>>
    {
    }
}