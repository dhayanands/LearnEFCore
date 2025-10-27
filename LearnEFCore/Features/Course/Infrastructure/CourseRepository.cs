using CourseEntity = LearnEFCore.Domain.Entities.Course;
using LearnEFCore.Features.Course.Interfaces;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnEFCore.Features.Course.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<CourseEntity?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task AddCourseAsync(CourseEntity course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(CourseEntity course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(CourseEntity course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}