using Microsoft.EntityFrameworkCore;
using StudentProject.Data;
using StudentProject.Model;
using StudentProject.Repositories.Interfaces;

namespace StudentProject.Repositories
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
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public async Task<Student?> GetStudentByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
