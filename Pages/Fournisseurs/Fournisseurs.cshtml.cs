using AST1.Models;
using AST1.Models.ViewModels;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.Fournisseurs
{
    public class FournisseursModel : PageModel
    {

        private readonly Connection DbContext;
        public Models.Provider providers { get; set; }
        public FournisseursModel(Connection DbContext)
        {
            this.DbContext = DbContext;
            providers = new Models.Provider();
        }
        public void OnGet()
        {
                
        }

        public IActionResult OnPost()
        {
            var newProvider = new Provider()
            {
                NameProvider = providers.NameProvider,
                RaisonSocialProvider = providers.RaisonSocialProvider,
                AdresseProvider = providers.AdresseProvider,
                PaysProvider = providers.PaysProvider,
                MailProvider = providers.MailProvider,
                PrincipalProvider = providers.PrincipalProvider,
                ActifProvider = providers.ActifProvider,
                PhoneProvider = providers.PhoneProvider,
                Phone2Provider = providers.Phone2Provider
            };

            DbContext.providers.Add(newProvider);
            DbContext.SaveChanges();
            ViewData["Message"] = "Provider Added Successfully";
            return RedirectToPage("/Fournisseurs/Fournisseurs");
        }


    }
}
