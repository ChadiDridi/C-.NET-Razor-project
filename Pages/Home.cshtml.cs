using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Diagnostics;
namespace AST1.Pages
{
    public class HomeModel : PageModel
    {
       // private readonly IHttpContextAccessor _httpContextAccessor;
       public HomeModel()
        {
          //  _httpContextAccessor = httpContextAccessor;
        }
        public string LoggedInUserName { get; set; }

        public void OnGet()
        {
           // _httpContextAccessor.HttpContext.Session.SetString("LoggedInName","Chadi");
           // _httpContextAccessor.HttpContext.Session.SetInt32("Id", 1);

        }
    }
}
