using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Course.DTOs;

namespace LearnEFCore.Features.Course.Commands
{
    public class CreateCourseCommand : Command<int>
    {
        public CreateCourseDto CourseDto { get; set; }
    }
}