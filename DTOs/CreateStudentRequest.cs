using System.ComponentModel.DataAnnotations;

namespace StudentProject.DTOs
{
    public class CreateStudentRequest
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }

    public class UpdateStudentRequest
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
