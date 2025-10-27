using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Interfaces
{
 public interface IStudentService
 {
 Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
 Task<StudentDto?> GetStudentByIdAsync(int id);
 Task<StudentDto> CreateStudentAsync(CreateStudentDto dto);
 Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto);
 Task<bool> DeleteStudentAsync(int id);
 }
}