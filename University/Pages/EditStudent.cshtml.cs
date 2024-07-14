using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace University.Pages
{
    public class EditStudentModel : PageModel
    {
        [BindProperty]
        public string StudentId { get; set; } = string.Empty;
        public void OnGet()
        {
        }
    }
}
