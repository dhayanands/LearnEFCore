using LearnEFCore.Core.Entities;

namespace LearnEFCore.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context, ILogger logger)
        {
            logger.LogInformation("Seeding database with test data...");

            // Add sample students
            context.Students.AddRange(
                new Student
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    EnrollmentDate = new DateTime(2022, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    Course = "Computer Science"
                },
                new Student
                {
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    EnrollmentDate = new DateTime(2023, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                    Course = "Mathematics"
                },
                new Student
                {
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    EnrollmentDate = new DateTime(2021, 5, 20, 0, 0, 0, DateTimeKind.Utc),
                    Course = "Physics"
                }
            );

            await context.SaveChangesAsync();

            logger.LogInformation("Database seeding complete.");
        }
    }
}