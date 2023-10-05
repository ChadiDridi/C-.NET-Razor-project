using AST1.Models;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AST1.Pages.Materiels
{
    public class ListModel : PageModel
    {
        private readonly Connection _connection;
        public List<Hardware> hardwares { get; set; }
        public ListModel(Connection connection)
        {
            hardwares = new List<Hardware>();
            _connection = connection;
        }
        public void OnGet()
        {
            hardwares= _connection.GetAllHardwares();
        }
        public IActionResult OnPostDelete(int id) { 
         try
            {
                // Call your delete method from the Connection class
                _connection.DeleteHardware(id);

                TempData["successMessage"] = "Hardware deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "An error occurred while deleting the employer: " + ex.Message;
            }

return RedirectToPage("/Materiels/List");
    
}
}
}
