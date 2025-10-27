using LearnEFCore.Application.Services;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Interfaces;
using LearnEFCore.Features.Student.Queries;

namespace LearnEFCore.Features.Student.Handlers
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, StudentDto?>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto?> Handle(GetStudentByIdQuery query)
        {
            var student = await _studentRepository.GetStudentByIdAsync(query.Id);
            return student == null ? null : StudentMapper.ToDto(student);
        }
    }
}