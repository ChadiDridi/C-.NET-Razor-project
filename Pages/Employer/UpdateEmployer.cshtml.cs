using AST1.Models.ViewModels;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.Employer
{
    public class UpdateEmployerModel : PageModel
    {

        private Connection _conn { get; set; }
        public Models.Employerh Employer { get; set; }
        public List<Models.Employerh> Employees { get; set; }
        


        public UpdateEmployerModel(Connection _conn)
        {
            this._conn = _conn;
            Employees = _conn.GetAll(); // Fetch all employees from your data source

        }

        public void OnGet(int id)
        {
            var employer = _conn.GetEmployeeById(id);


            Employer = employer; // Assign the retrieved employer directly to the property
           // return Page();
        }

        [ValidateAntiForgeryToken]
        public   IActionResult OnPostUpdateEmployer(int id, Models.Employerh updateEmployeeRequest)
        {
            var originalEmployer = _conn.GetEmployeeById(id);


            originalEmployer.NomEmployer = updateEmployeeRequest.NomEmployer;
            originalEmployer.PrenomEmployer = updateEmployeeRequest.PrenomEmployer;
            originalEmployer.EmailEmployer = updateEmployeeRequest.EmailEmployer;
            originalEmployer.PosteEmployer = updateEmployeeRequest.PosteEmployer;
            originalEmployer.TelephoneEmployer = updateEmployeeRequest.TelephoneEmployer;

            _conn.UpdateEmployee(id,originalEmployer); // Update the employee with the modified properties

            return RedirectToPage("/Employer/List");

        }
        

    }
}
