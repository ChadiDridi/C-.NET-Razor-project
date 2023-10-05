namespace AST1.Models
{
    public class CookiesConfig
    { 

         // classe CookingConfig admettant les attributs et leur constructeurs suivant le Modele MVC
         // Model Vue Controller 
        public string CookieName { get; set; }

        public string LoginPath { get; set; }

        public string LogoutPath { get; set; }

        public string AccessDeniedPath { get; set; }

        public string ReturnUrlParameter { get; set; }
    }
}
