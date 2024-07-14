using EdgeDB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using University.Models;

namespace University.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly EdgeDBClient _client;
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty (SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public LoginModel(EdgeDBClient client)
        {
            _client = client;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                string query = "SELECT Account{username} FILTER .username = <str>$Username AND .password = <str>$Password;";
                var account = await _client.QuerySingleAsync<AccountModel>(query, new Dictionary<string, Object?>
                {
                    {"Username", Username },
                    {"Password", Password }
                });
                if (account is not null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(type: "sub", value: Username)
                    };

                    var ci = new ClaimsIdentity(claims, "cookie"); // Specify the authentication type here
                    var cp = new ClaimsPrincipal(ci);

                    await HttpContext.SignInAsync("cookie", cp); // Specify the authentication scheme here

                    return LocalRedirect(ReturnUrl);
                }
            }
            return Page();
        }
    }
}
