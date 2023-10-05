using AST1.Models;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.BonAchat
{
    public class ListModel : PageModel
    {
        private readonly Connection _connection;
        public List<Models.Order> BonAchats { get; set; }
        public ListModel(Connection connection)
        {
            _connection = connection;
        }

        public void OnGet()
        {
            BonAchats = _connection.GetAllOrders();
        }
        [BindProperty]
        public Order order { get; set; }
        
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                _connection.DeleteOrder(id);

                TempData["successMessage"] = "Order deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "An error occurred while deleting the Order: " + ex.Message;
            }

            return RedirectToPage("/BonAchat/List");
        }
        public IActionResult OnGetEdit(int id)
        {
       
            {
                TempData["errorMessage"] = "Employer not found.";
                return RedirectToPage("/BonAchat/List");
            }

            return RedirectToPage("/BonAchat/BonAchat");
        }


    }

    }


