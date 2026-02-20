using StudentProject.DTOs;
using StudentProject.Model;
using StudentProject.Repositories.Interfaces;
using StudentProject.Services.Interface;

namespace StudentProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return students.Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email
            });
        }

        public async Task<StudentResponse?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null) return null;
            return new StudentResponse
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Email = student.Email
            };
        }

        public async Task<StudentResponse> AddStudentAsync(CreateStudentRequest request)
        {
            var existingStudent = await _studentRepository.GetStudentByEmailAsync(request.Email);
            if (existingStudent != null)
            {
                throw new Exception("A student with this email already exists.");
            }
            var student = new Student
            {
                Name = request.Name,
                Age = request.Age,
                Email = request.Email
            };
            await _studentRepository.AddStudentAsync(student);
            await _studentRepository.SaveChangesAsync();
            return new StudentResponse
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Email = student.Email
            };
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentRequest request)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null) return false;
            student.Name = request.Name;
            student.Age = request.Age;
            student.Email = request.Email;
            _studentRepository.UpdateStudent(student);
            await _studentRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null) return false;
            _studentRepository.DeleteStudent(student);
            await _studentRepository.SaveChangesAsync();
            return true;
        }
    }
}
