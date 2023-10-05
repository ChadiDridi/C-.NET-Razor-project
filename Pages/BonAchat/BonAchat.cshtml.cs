using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.BonAchat
{
    public class BonAchatModel : PageModel
    {
        private Connection _connection;

        public BonAchatModel(Connection connection)
        {
            _connection = connection;
        }

        [BindProperty]
        public Models.Order NewOrder { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {

            var order = new Models.Order
            {
                IdOrder=NewOrder.IdOrder,
                DesignationOrder=NewOrder.DesignationOrder,
                ReferenceOrder = NewOrder.ReferenceOrder,
                QtsOrder= NewOrder.QtsOrder,
                SnOrder= NewOrder.SnOrder,
                IdProvider= NewOrder.IdProvider,
                QuantiteOrder= NewOrder.QuantiteOrder

                
            };
            _connection.BonAchats.Add(order);
            _connection.SaveChanges();
            ViewData["Message"] = "Order Added Successfully";
            return Redirect("/BonAchat/List");
        }
    }
}
