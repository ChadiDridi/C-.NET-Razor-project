using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.Fournisseurs
{
    public class UpdateModel : PageModel
    {
        private Connection _conn { get; set; }
        public Models.Provider provider { get; set; }
        public List<Models.Employerh> providers { get; set; }



      //  public UpdateFournisseur(Connection _conn)
       // {
         //   this._conn = _conn;
            //providers = _conn.GetAllProviders(); // Fetch all employees from your data source

       // }

        public void OnGet(int id)
        {
            var Providerr = _conn.GetProviderById(id);


            Providerr = provider; // Assign the retrieved employer directly to the property  
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPostUpdateProvider(int id, Models.Provider updateProviderRequest)
        {
            var originalProvider = _conn.GetProviderById(id);

           

            originalProvider.PrincipalProvider = updateProviderRequest.PrincipalProvider;
            originalProvider.AdresseProvider = updateProviderRequest.AdresseProvider;
            originalProvider.NameProvider = updateProviderRequest.NameProvider;
            originalProvider.ActifProvider = updateProviderRequest.ActifProvider;
            originalProvider.MailProvider = updateProviderRequest.MailProvider;
            originalProvider.PaysProvider = updateProviderRequest.PaysProvider;
            originalProvider.Phone2Provider = updateProviderRequest.Phone2Provider;
            originalProvider.PhoneProvider = updateProviderRequest.PhoneProvider;
            originalProvider.RaisonSocialProvider = updateProviderRequest.RaisonSocialProvider;
            _conn.UpdateProvider(originalProvider); // Update the provider with the modified properties

            return RedirectToPage("/Employer/List");
        }


    }
}