using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.Fournisseurs
{
    public class ListModel : PageModel
    {

        private readonly Connection DbContext;
        public List<Models.Provider> providers { get; set; }
        public ListModel(Connection DbContext)
        {
            this.DbContext = DbContext;
            providers = new List<Models.Provider>();
        }
        public void OnGet()
        {
            providers = DbContext.GetAllProviders();
        }

        public IActionResult OnPostDelete(int id)
        {
            DbContext.DeleteProvider(id);
            return RedirectToPage();
        }
       public void OnPost() { }

    }
}