using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class StudentModel
    {
        public string StudentId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long Age { get; set; } = 0;
        public List<CourseModel> Courses { get; set; } = [];
        public DepartmentModel Department { get; set; } = new();
    }
}
