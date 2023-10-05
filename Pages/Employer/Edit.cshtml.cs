using AST1.Models;
using AST1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using AST1.SQLConnection;

namespace AST1.Pages.Employer
{
    public class EditModel : PageModel
    { private readonly Connection connection;

        [BindProperty]
        public Models.Employerh EditEmployeeViewModel { get; set; }
        public EditModel(Connection dbContext)
        {
            connection=dbContext;
        }
        public void OnGet(int id)
        {
            EditEmployeeViewModel = connection.Employees.Find(id);
            if (EditEmployeeViewModel != null)
            {
                var viewModel = new AddEmloyerViewModel
                { IdEmployer = EditEmployeeViewModel.IdEmployer,
                    NomEmployer = EditEmployeeViewModel.NomEmployer,
                    PrenomEmployer = EditEmployeeViewModel.PrenomEmployer,
                    EmailEmployer = EditEmployeeViewModel.EmailEmployer,
                    PosteEmployer = EditEmployeeViewModel.PosteEmployer,
                    TelephoneEmployer = EditEmployeeViewModel.TelephoneEmployer,
                    Services = EditEmployeeViewModel.Services
                };
            }
        }
        public IActionResult OnPost()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = connection.Employees.Find(EditEmployeeViewModel.IdEmployer);
                if (existingEmployee != null)
                {
                    existingEmployee.NomEmployer = EditEmployeeViewModel.NomEmployer;
                    existingEmployee.PrenomEmployer = EditEmployeeViewModel.PrenomEmployer;
                    existingEmployee.EmailEmployer = EditEmployeeViewModel.EmailEmployer;
                    existingEmployee.PosteEmployer = EditEmployeeViewModel.PosteEmployer;
                    existingEmployee.TelephoneEmployer = EditEmployeeViewModel.TelephoneEmployer;
                    existingEmployee.Services = EditEmployeeViewModel.Services;

                    connection.UpdateEmployee(existingEmployee.IdEmployer,existingEmployee);
                    ViewData["Message"] = "Employer Updated Successfully";
                }
            }
            return RedirectToPage("/List");
        }



    }
}
