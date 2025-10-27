using LearnEFCore.Application.Services;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Interfaces;
using LearnEFCore.Features.Student.Queries;

namespace LearnEFCore.Features.Student.Handlers
{
    public class GetStudentsQueryHandler : IQueryHandler<GetStudentsQuery, List<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> Handle(GetStudentsQuery query)
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return students.Select(StudentMapper.ToDto).ToList();
        }
    }
}