using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AST1.SQLConnection;
namespace AST1.Pages.Materiels
{
    public class MaterielModel : PageModel
    {
        private Connection _connection;

        public MaterielModel(Connection connection)
        {
            _connection = connection;
        }

        [BindProperty]
        public Models.Hardware Hardware { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {

            var hardware = new Models.Hardware
            {

                DateHardware = Hardware.DateHardware,
                DescriptionHardware = Hardware.DescriptionHardware,
                TypeHardware= Hardware.TypeHardware,
                EtatHardware = Hardware.EtatHardware,
                MarqueHardware = Hardware.MarqueHardware,
                ModelHardware = Hardware.ModelHardware,
                AvailableHardware = Hardware.AvailableHardware,
                GrantieHardware= Hardware.GrantieHardware,
                ConsommableHardware= Hardware.ConsommableHardware,
                LoginHardware= Hardware.LoginHardware,
                IdOrder= Hardware.IdOrder
            };
            _connection.hardwares.Add(hardware);
            _connection.SaveChanges();
            ViewData["Message"] = "Hardware Added Successfully";
            return Redirect("/Materiels/List");
        }
    }
}

