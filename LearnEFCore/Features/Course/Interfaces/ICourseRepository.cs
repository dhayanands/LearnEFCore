using CourseEntity = LearnEFCore.Domain.Entities.Course;

namespace LearnEFCore.Features.Course.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseEntity>> GetAllCoursesAsync();
        Task<CourseEntity?> GetCourseByIdAsync(int id);
        Task AddCourseAsync(CourseEntity course);
        Task UpdateCourseAsync(CourseEntity course);
        Task DeleteCourseAsync(CourseEntity course);
    }
}