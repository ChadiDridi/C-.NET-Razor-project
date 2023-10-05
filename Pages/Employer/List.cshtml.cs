
using AST1.Models;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace AST1.Pages.Employer
{
    public class ListModel : PageModel
    {

        private readonly Connection _connection;
        public List<Models.Employerh> employees { get; set; }
        public ListModel(Connection connection)
        {
            _connection = connection;
        }
        public void OnGet()
        {

            employees = _connection.GetAll();
        }
        public void OnPost()
        {
            //post table of registered Employers in the database

        }
        protected void Page_Load(object sender, System.EventArgs e)
        {

        }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                // Call your delete method from the Connection class
                _connection.DeleteEmployee(id);

                TempData["successMessage"] = "Employer deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "An error occurred while deleting the employer: " + ex.Message;
            }

            return RedirectToPage("/Employer/List");



        }


    }
}

