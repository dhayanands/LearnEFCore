using Microsoft.EntityFrameworkCore;
using LearnEFCore.Core.Entities;
using LearnEFCore.Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Students.Any())
        {
            context.Students.AddRange(new[]
            {
                new Student
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    EnrollmentDate = DateTime.UtcNow.AddYears(-1), // Convert to UTC
                    Course = "Computer Science"
                },
                new Student
                {
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    EnrollmentDate = DateTime.UtcNow.AddYears(-2), // Convert to UTC
                    Course = "Mathematics"
                },
                new Student
                {
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    EnrollmentDate = DateTime.UtcNow.AddYears(-3), // Convert to UTC
                    Course = "Physics"
                }
            });

            context.SaveChanges();
        }
    }
}