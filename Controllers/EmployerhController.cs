
using AST1.Models;
using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AST1.SQLConnection;
using AST1.Pages.Employer;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using AST1.SQLConnection;
using Microsoft.AspNetCore;
using Microsoft.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace AST1.Controllers
{
    public class EmployerhController : Controller
    {  private  Connection _conn;

        public EmployerhController(Connection conn)
        {
            _conn = conn;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List < Employerh > employees= new List<Employerh>();
            employees = await _conn.Employees.ToListAsync();
            try
            {
                employees = _conn.GetAll();
            }
            catch (Exception ex)
            {
                
                TempData["error msg"]= ex.Message;
            }   
            return View();
        }
        [NonAction]
        private JsonResult GetEmployers()
        {
            var employers = _conn.Employees.ToList();
            return Json(employers);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployer(Employerh addEmployeeRequest)
        {  if(!ModelState.IsValid)
            {
                return View();
            }

            var employer = new Employerh()
            {
                IdEmployer = addEmployeeRequest.IdEmployer,
                NomEmployer = addEmployeeRequest.NomEmployer,
                PrenomEmployer = addEmployeeRequest.PrenomEmployer,
                EmailEmployer = addEmployeeRequest.EmailEmployer,
                PosteEmployer = addEmployeeRequest.PosteEmployer,
                TelephoneEmployer = addEmployeeRequest.TelephoneEmployer,
                //Services ?= addEmployeeRequest.Services
                PasswordEmployer=addEmployeeRequest.PasswordEmployer
            };
             await _conn.AddAsync(employer);
           await  _conn.SaveChangesAsync();
            return RedirectToAction("AddEmployer");
        }
        [HttpPost]
        public IActionResult CreerEmployer()
        {


            return View();

        }
        public IActionResult CreerEmployer(Employerh addEmployeeRequest) { 
            var employer = new Employerh()
            {
                IdEmployer = addEmployeeRequest.IdEmployer,
                NomEmployer = addEmployeeRequest.NomEmployer,
                PrenomEmployer = addEmployeeRequest.PrenomEmployer,
                EmailEmployer = addEmployeeRequest.EmailEmployer,
                PosteEmployer = addEmployeeRequest.PosteEmployer,
                TelephoneEmployer = addEmployeeRequest.TelephoneEmployer,
                //Services ?= addEmployeeRequest.Services
                PasswordEmployer = addEmployeeRequest.PasswordEmployer
            };
             _conn.Add(employer);
             _conn.SaveChanges();
            return RedirectToAction("AddEmployer");

        }
        [HttpPost]
        public IActionResult UpdateEmployer(Employerh addEmployeeRequest)
        {
            var employer = new Employerh()
            {
                NomEmployer = addEmployeeRequest.NomEmployer,
                PrenomEmployer = addEmployeeRequest.PrenomEmployer,
                EmailEmployer = addEmployeeRequest.EmailEmployer,
                PosteEmployer = addEmployeeRequest.PosteEmployer,
                TelephoneEmployer = addEmployeeRequest.TelephoneEmployer,
                Services = addEmployeeRequest.Services
            };
             _conn.Update(employer);
             _conn.SaveChangesAsync();
            return RedirectToAction("UpdateEmployer");
        }
        public IActionResult Create(Employerh employer)
        {
            if(!ModelState.IsValid)
            {
                TempData["errorMessage"]= "An error occurred while adding the employer: ";
            }
            bool result = _conn.Insert(employer);
            if (!result)
            {
                TempData["errorMessage"] = "uable to save the data";
                return View();
            }
            TempData ["sucessMessage"] = "Employer added successfully.";
            return RedirectToAction("Index");
        }
    
              

    }
}
