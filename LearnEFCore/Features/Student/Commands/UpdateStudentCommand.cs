using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Commands
{
    public class UpdateStudentCommand : ICommand
    {
        public int Id { get; set; }
        public UpdateStudentDto StudentDto { get; set; }
    }
}