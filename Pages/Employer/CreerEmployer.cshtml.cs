
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
    public class loginModel : PageModel

    {
        private readonly Connection DbContext;
        public loginModel(Connection DbContext)
        {
            this.DbContext = DbContext;

        }

        [BindProperty]
        public AddEmloyerViewModel AddEmloyerViewModel { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            //  if (ModelState.IsValid)
            {
                var employer = new Models.Employerh
                {
                    NomEmployer = AddEmloyerViewModel.NomEmployer,
                    PrenomEmployer = AddEmloyerViewModel.PrenomEmployer,
                    EmailEmployer = AddEmloyerViewModel.EmailEmployer,
                    PosteEmployer = AddEmloyerViewModel.PosteEmployer,
                    TelephoneEmployer = AddEmloyerViewModel.TelephoneEmployer,
                    Services = AddEmloyerViewModel.Services,
                    PasswordEmployer = AddEmloyerViewModel.PasswordEmployer
                };
                DbContext.Employees.Add(employer);
                DbContext.SaveChanges();
                ViewData["Message"] = "Employer Added Successfully";
                return RedirectToPage("/Employer/List");
            }

        }
    }
}
