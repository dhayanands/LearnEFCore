using LearnEFCore.Application.Interfaces;

namespace LearnEFCore.Features.Student.Commands
{
    public class DeleteStudentCommand : Command
    {
        public int Id { get; set; }
    }
}