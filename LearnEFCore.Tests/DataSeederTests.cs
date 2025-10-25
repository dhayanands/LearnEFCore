using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LearnEFCore.Tests
{
    public class DataSeederTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly Mock<ILogger> _loggerMock;

        public DataSeederTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _loggerMock = new Mock<ILogger>();
        }

        [Fact]
        public async Task SeedAsync_ShouldAddStudentsToDatabase()
        {
            // Arrange
            // Ensure database is empty
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            // Act
            await DataSeeder.SeedAsync(_context, _loggerMock.Object);

            // Assert
            var students = await _context.Students.ToListAsync();
            Assert.Equal(3, students.Count);

            var john = students.First(s => s.Name == "John Doe");
            Assert.Equal("john.doe@example.com", john.Email);
            Assert.Equal("Computer Science", john.Course);
            Assert.Equal(new DateTime(2022, 9, 1, 0, 0, 0, DateTimeKind.Utc), john.EnrollmentDate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}