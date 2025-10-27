using LearnEFCore.Application.Services;
using LearnEFCore.Features.Student.Commands;
using LearnEFCore.Features.Student.Interfaces;

namespace LearnEFCore.Features.Student.Handlers
{
    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Handle(UpdateStudentCommand command)
        {
            var student = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (student == null) throw new KeyNotFoundException("Student not found");

            // Update properties
            if (command.StudentDto.Name != null) student.Name = command.StudentDto.Name;
            if (command.StudentDto.Email != null) student.Email = command.StudentDto.Email;
            if (command.StudentDto.EnrollmentDate.HasValue) student.EnrollmentDate = command.StudentDto.EnrollmentDate.Value;
            if (command.StudentDto.Course != null) student.Course = command.StudentDto.Course;

            await _studentRepository.UpdateStudentAsync(student);
        }
    }
}