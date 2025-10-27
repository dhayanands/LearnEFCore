namespace LearnEFCore.Features.Student.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public string Course { get; set; } = string.Empty;
    }
}