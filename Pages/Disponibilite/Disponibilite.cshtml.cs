using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AST1.Controllers;
using AST1.Models;
using AST1.SQLConnection;
using System.Data.SqlClient;
namespace AST1.Pages.Disponibilite
{
    public class DisponibiliteModel : PageModel
    { public List<Hardware> disponibles = new List<Hardware>();
        private readonly Connection _connection;

        public DisponibiliteModel(Connection connection)
        {
            _connection = connection;
        }

        public void OnGet()
        {
           disponibles= _connection.GetAllDisponibles();
            
         }
        public void OnPost() { }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                // Call your delete method from the Connection class
                _connection.DeleteDisponible(id);

                TempData["successMessage"] = "Hardware updated successfully.";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "An error occurred while deleting the Hardware: " + ex.Message;
            }

            return RedirectToPage("/Disponibilite/Disponibilite");
        }
    }
            
        
    }

