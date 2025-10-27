using LearnEFCore.Domain.Entities;

namespace LearnEFCore.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context, ILogger logger)
        {
            logger.LogInformation("Seeding database with test data...");

            // Add sample courses
            var csCourse = new Course
            {
                Title = "Computer Science",
                Description = "Study of computers and computational systems."
            };
            var mathCourse = new Course
            {
                Title = "Mathematics",
                Description = "Study of numbers, quantities, and shapes."
            };
            var physicsCourse = new Course
            {
                Title = "Physics",
                Description = "Study of matter, energy, and the fundamental forces of nature."
            };

            context.Courses.AddRange(csCourse, mathCourse, physicsCourse);

            // Add sample students and map them to courses
            var john = new Student
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                EnrollmentDate = new DateTime(2022, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                Course = "Computer Science",
                Courses = new List<Course> { csCourse }
            };
            var jane = new Student
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                EnrollmentDate = new DateTime(2023, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                Course = "Mathematics",
                Courses = new List<Course> { mathCourse }
            };
            var alice = new Student
            {
                Name = "Alice Johnson",
                Email = "alice.johnson@example.com",
                EnrollmentDate = new DateTime(2021, 5, 20, 0, 0, 0, DateTimeKind.Utc),
                Course = "Physics",
                Courses = new List<Course> { physicsCourse }
            };

            context.Students.AddRange(john, jane, alice);

            await context.SaveChangesAsync();

            logger.LogInformation("Database seeding complete.");
        }
    }
}