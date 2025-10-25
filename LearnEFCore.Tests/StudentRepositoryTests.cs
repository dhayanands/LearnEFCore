using LearnEFCore.Core.Entities;
using LearnEFCore.Infrastructure.Data;
using LearnEFCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace LearnEFCore.Tests
{
    public class StudentRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public StudentRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudents()
        {
            // Arrange
            using var context = new AppDbContext(_options);
            context.Students.AddRange(
                new Student { Name = "Test Student 1", Email = "test1@example.com", EnrollmentDate = DateTime.Now, Course = "Math" },
                new Student { Name = "Test Student 2", Email = "test2@example.com", EnrollmentDate = DateTime.Now, Course = "Science" }
            );
            await context.SaveChangesAsync();

            var repository = new StudentRepository(context);

            // Act
            var students = await repository.GetAllStudentsAsync();

            // Assert
            Assert.Equal(2, students.Count());
        }
    }
}