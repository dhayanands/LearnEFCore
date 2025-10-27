using LearnEFCore.Application.Services;
using LearnEFCore.Features.Student.Commands;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Interfaces;

namespace LearnEFCore.Features.Student.Handlers
{
    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<CreateStudentCommandHandler> _logger;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, ILogger<CreateStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStudentCommand command)
        {
            try
            {
                _logger.LogInformation("Creating student with name {Name}", command.StudentDto.Name);
                var student = StudentMapper.ToEntity(command.StudentDto);
                await _studentRepository.AddStudentAsync(student);
                _logger.LogInformation("Student created with ID {Id}", student.Id);
                return student.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating student");
                throw;
            }
        }
    }
}