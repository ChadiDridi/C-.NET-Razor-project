using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AST1.SQLConnection;
using AST1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace AST1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SQLConnection.Connection _dbContext;
        [BindProperty]
        public Models.Employerh Employer { get; set; }
        public IndexModel(Connection dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            //No http get actions
        }

        public IActionResult OnPost()
        {


            var user = _dbContext.Employees.FirstOrDefault(e =>
        e.EmailEmployer == Employer.EmailEmployer &&
        e.PasswordEmployer == Employer.PasswordEmployer
    );

            if (user != null)
            {
                var claims = new[]
                {

                    new Claim(ClaimTypes.Name, user.NomEmployer),
                };
                var identity = new System.Security.Claims.ClaimsIdentity(claims, "Login");
                var principal = new System.Security.Claims.ClaimsPrincipal(identity);

              //  HttpContext.Session.SetString("LoggedInUserName", user.NomEmployer);


                return RedirectToPage("/Home");

            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid email or password.";
                return Page();
            }
            return Page();
        }
    }
}

