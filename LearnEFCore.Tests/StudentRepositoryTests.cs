using StudentEntity = LearnEFCore.Domain.Entities.Student;
using LearnEFCore.Features.Student.Infrastructure;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnEFCore.Tests
{
    public class StudentRepositoryTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly StudentRepository _repository;

        public StudentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repository = new StudentRepository(_context);
        }

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudents()
        {
            // Arrange
            _context.Students.AddRange(
                new StudentEntity { Name = "Test Student 1", Email = "test1@example.com", EnrollmentDate = DateTime.Now, Course = "Math" },
                new StudentEntity { Name = "Test Student 2", Email = "test2@example.com", EnrollmentDate = DateTime.Now, Course = "Science" }
            );
            await _context.SaveChangesAsync();

            // Act
            var students = await _repository.GetAllStudentsAsync();

            // Assert
            Assert.Equal(2, students.Count());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}