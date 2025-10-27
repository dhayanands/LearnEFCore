using System.ComponentModel.DataAnnotations;

namespace LearnEFCore.Features.Student.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public string Course { get; set; } = string.Empty;
    }
}