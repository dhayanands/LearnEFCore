using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Interfaces;

namespace LearnEFCore.Features.Student.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllStudentsAsync();
        return students.Select(s => s.ToDto());
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        return student?.ToDto();
    }

    public async Task<bool> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        if (student == null) return false;

        if (dto.Name != null) student.Name = dto.Name;
        if (dto.Email != null) student.Email = dto.Email;
        if (dto.EnrollmentDate.HasValue) student.EnrollmentDate = dto.EnrollmentDate.Value;
        if (dto.Course != null) student.Course = dto.Course;

        await _studentRepository.UpdateStudentAsync(student);
        return true;
    }

    public async Task<StudentDto> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = dto.ToEntity();
        await _studentRepository.AddStudentAsync(student);
        return student.ToDto();
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        if (student == null) return false;

        await _studentRepository.DeleteStudentAsync(student);
        return true;
    }
}