using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class StudentModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? StudentId { get; set; }
        [Required]
        public int? Age { get; set; }
        public Course[] Courses { get; set; } = [];
        public Department? Department { get; set; }
    }
}
