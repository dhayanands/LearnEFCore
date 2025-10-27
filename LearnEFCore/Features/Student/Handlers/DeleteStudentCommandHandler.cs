using LearnEFCore.Application.Services;
using LearnEFCore.Domain.Entities;
using LearnEFCore.Features.Student.Commands;
using LearnEFCore.Features.Student.Interfaces;

namespace LearnEFCore.Features.Student.Handlers
{
    public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Handle(DeleteStudentCommand command)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null) throw new KeyNotFoundException("Student not found");

            await _studentRepository.DeleteStudentAsync(student);
        }
    }
}