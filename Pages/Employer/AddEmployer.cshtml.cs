
using AST1.Models.ViewModels;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AST1.Models.ViewModels;
using AST1.Models;
using System.Drawing;
using AST1.Models.ViewModels;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AST1.Models.ViewModels;
using AST1.Models;
using System.Drawing;
using System.Data.Entity;
using AST1.Pages;
using AST1.Models.ViewModels;
namespace AST1.Pages.Employer
{
    public class AddEmployerModel : PageModel

    {
        private  Connection connection;
        public AddEmployerModel(Connection DbContext)
        {
            this.connection = DbContext;

        }

        [BindProperty]
        public Models.Employerh Employer { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            //  if (ModelState.IsValid)
            {
                var employer = new Models.Employerh
                {
                    NomEmployer = Employer.NomEmployer,
                    PrenomEmployer = Employer.PrenomEmployer,
                    EmailEmployer = Employer.EmailEmployer,
                    PosteEmployer = Employer.PosteEmployer,
                    TelephoneEmployer = Employer.TelephoneEmployer,
                    Services = Employer.Services,
                    PasswordEmployer = Employer.PasswordEmployer
                };
                connection.Employees.Add(employer);
                connection.SaveChanges();
                ViewData["Message"] = "Employer Added Successfully";
                return RedirectToPage("/Employer/List");
            }

        }
    }
}
