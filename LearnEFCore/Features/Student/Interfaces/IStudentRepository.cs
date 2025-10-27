using StudentEntity = LearnEFCore.Domain.Entities.Student;

namespace LearnEFCore.Features.Student.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentEntity>> GetAllStudentsAsync();
        Task<StudentEntity?> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(StudentEntity student);
        Task AddStudentAsync(StudentEntity student);
        Task DeleteStudentAsync(StudentEntity student);
    }
}