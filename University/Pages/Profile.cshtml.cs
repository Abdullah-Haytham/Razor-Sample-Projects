using EdgeDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Models;

namespace University.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly EdgeDBClient _client;
        [BindProperty]
        public StudentModel Student { get; set; } = new();

        public ProfileModel(EdgeDBClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var StudentId = User.FindFirst("sub").ToString().Split(" ")[1];
            if(StudentId is not null)
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
            }
            return Page();
        }
    }
}
