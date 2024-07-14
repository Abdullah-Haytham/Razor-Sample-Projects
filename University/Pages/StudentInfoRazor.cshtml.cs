using EdgeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Models;

namespace University.Pages
{
    public class StudentInfoRazorModel : PageModel
    {
        private readonly EdgeDBClient _client;
        [BindProperty (SupportsGet = true)]
        public string StudentId { get; set; } = string.Empty;

        [BindProperty]
        public StudentModel Student { get; set; } = new();

        public StudentInfoRazorModel(EdgeDBClient client)
        {
            _client = client;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(StudentId))
            {
                return Page();
            }
            else
            {
                string query = @"
            SELECT Student {
                student_id,
                name,
                age,
                courses: {
                    name,
                    code,
                    credit,
                    department: {
                        name,
                        code
                    },
                    students
                },
                department: {
                    name,
                    code,
                    students,
                }
            }
            FILTER .student_id = <str>$studentId";
                Student = await _client.QuerySingleAsync<StudentModel>(query, new Dictionary<string, Object?>
        {
            {"studentId", StudentId},
        });
                return Page();
            }  
        }
    }
}
