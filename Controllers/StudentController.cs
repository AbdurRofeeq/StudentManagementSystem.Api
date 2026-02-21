using Microsoft.AspNetCore.Mvc;
using StudentProject.DTOs;
using StudentProject.Services.Interface;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentRequest request)
        {
            try
            {
                var student = await _studentService.AddStudentAsync(request);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentRequest request)
        {
            var result = await _studentService.UpdateStudentAsync(id, request);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }


    }
}
