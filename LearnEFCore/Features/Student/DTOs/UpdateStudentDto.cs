using System.ComponentModel.DataAnnotations;

namespace LearnEFCore.Features.Student.DTOs
{
    public class UpdateStudentDto
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime? EnrollmentDate { get; set; }
        public string? Course { get; set; }
    }
}