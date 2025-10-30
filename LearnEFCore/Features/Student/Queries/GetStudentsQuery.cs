using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Queries
{
    public class GetStudentsQuery : Query<List<StudentDto>>
    {
    }
}