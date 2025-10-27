using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Commands
{
    public class CreateStudentCommand : ICommand<int>
    {
        public CreateStudentDto StudentDto { get; set; }
    }
}