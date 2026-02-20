using StudentProject.Model;

namespace StudentProject.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        Task<Student?> GetStudentByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}
