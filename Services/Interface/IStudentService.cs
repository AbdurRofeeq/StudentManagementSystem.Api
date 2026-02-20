using StudentProject.DTOs;
using System.Runtime.InteropServices;

namespace StudentProject.Services.Interface
{
    public interface IStudentService
    {
            Task<IEnumerable<StudentResponse>>GetAllStudentsAsync();
            Task<StudentResponse?> GetStudentByIdAsync(int id);
            Task <StudentResponse> AddStudentAsync(CreateStudentRequest request);
            Task<bool> UpdateStudentAsync(int Id, UpdateStudentRequest request);
            Task<bool> DeleteStudentAsync(int id);
    }
}
