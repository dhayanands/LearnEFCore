using LearnEFCore.Application.Interfaces;

namespace LearnEFCore.Features.Student.Commands
{
    public class DeleteStudentCommand : ICommand
    {
        public int Id { get; set; }
    }
}