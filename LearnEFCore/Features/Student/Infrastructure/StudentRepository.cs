using StudentEntity = LearnEFCore.Domain.Entities.Student;
using LearnEFCore.Features.Student.Interfaces;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnEFCore.Features.Student.Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentEntity>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentEntity?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id) ?? null;
        }

        public async Task UpdateStudentAsync(StudentEntity student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(StudentEntity student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(StudentEntity student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}