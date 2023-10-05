using Microsoft.AspNetCore.Mvc;
using AST1.Models;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AST1.SQLConnection;
using AST1.Pages.Employer;
using Microsoft.EntityFrameworkCore;
namespace AST1.Controllers
{
    public class DisponibilteController : Controller
    {
        private readonly Connection _conn;
        public DisponibilteController(Connection conn)
        {
            conn = _conn;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
