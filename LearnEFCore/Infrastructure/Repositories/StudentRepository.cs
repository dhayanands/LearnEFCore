using LearnEFCore.Application.Interfaces;
using LearnEFCore.Core.Entities;
using LearnEFCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnEFCore.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id) ?? null;
        }
    }
}