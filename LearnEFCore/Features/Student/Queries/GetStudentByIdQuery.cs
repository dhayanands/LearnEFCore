using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Queries
{
    public class GetStudentByIdQuery : IQuery<StudentDto?>
    {
        public int Id { get; set; }
    }
}