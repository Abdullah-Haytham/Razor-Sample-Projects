using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class CourseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public long Credit { get; set; } = 0;
        public List<StudentModel> Students { get; set; } = [];
        public DepartmentModel Department { get; set; } = [];
    }
}
