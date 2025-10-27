namespace LearnEFCore.Features.Student.DTOs;

using LearnEFCore.Domain.Entities;

public static class StudentMapper
{
    public static StudentDto ToDto(this Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            EnrollmentDate = student.EnrollmentDate,
            Course = student.Course
        };
    }

    public static Student ToEntity(this CreateStudentDto dto)
    {
        return new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            EnrollmentDate = dto.EnrollmentDate,
            Course = dto.Course
        };
    }
}