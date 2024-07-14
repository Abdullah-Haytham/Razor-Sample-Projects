using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using University.Models;

namespace University.Pages
{
    public class StudentInfoModel : PageModel
    {

        [BindProperty]
        public string? StudentId {  get; set; }

        [BindProperty]
        public StudentModel Student { get; set; } = new();
        public void OnGet()
        {
        }

    }
}
