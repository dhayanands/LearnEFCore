using LearnEFCore.Core.Entities;
using Xunit;

namespace LearnEFCore.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_ShouldHaveDefaultValues()
        {
            // Arrange & Act
            var student = new Student();

            // Assert
            Assert.Equal(0, student.Id);
            Assert.Equal(string.Empty, student.Name);
            Assert.Equal(string.Empty, student.Email);
            Assert.Equal(default(DateTime), student.EnrollmentDate);
            Assert.Equal(string.Empty, student.Course);
        }

        [Fact]
        public void Student_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var enrollmentDate = new DateTime(2022, 9, 1, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                EnrollmentDate = enrollmentDate,
                Course = "Computer Science"
            };

            // Assert
            Assert.Equal(1, student.Id);
            Assert.Equal("John Doe", student.Name);
            Assert.Equal("john.doe@example.com", student.Email);
            Assert.Equal(enrollmentDate, student.EnrollmentDate);
            Assert.Equal("Computer Science", student.Course);
        }
    }
}