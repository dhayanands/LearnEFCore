using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Commands
{
    public class CreateStudentCommand : Command<int>
    {
        public CreateStudentDto StudentDto { get; set; }
    }
}