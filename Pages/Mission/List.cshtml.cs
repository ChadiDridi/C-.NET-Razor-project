using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AST1.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection;
using System.Net;

namespace AST1.Pages.Mission
{
    public class ListModel : PageModel
    {
        private readonly Connection _connection;

        public ListModel(Connection connection)
        {
            _connection = connection;
        }
        public IActionResult OnGet()
        {
            Missions = _connection.GetAllMissions();


            foreach (var mission in Missions)
            {
                if (DateTime.TryParse(mission.DateReturnMission, out DateTime returnDate))
                {
                    if (returnDate < DateTime.Now.Date)
                    {

                        var subject = "Mission Reminder";
                        var body = $"Dear Employer,<br />" +
                            $"This is a reminder that your mission with ID {mission.IdMission} has surpassed its return date." +
                            $"Please take appropriate action.";

                       // SendEmail("dridichady@gmail.com", subject, body); Here select the email based on the EmployerId in table mission
                    }
                }
            }

            return Page();
        }

        public void OnPost()
        {
        }
        [BindProperty]
        public Missionh NewMission { get; set; }
        public List<Models.Mission> Missions { get; set; }
        public IActionResult OnPostDelete(int id)
        {
            try
            {
                // Call your delete method from the Connection class
                _connection.DeleteMission(id);

                TempData["successMessage"] = "Mission deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "An error occurred while deleting the Mission: " + ex.Message;
            }

            return RedirectToPage("/Mission/List");
        }
        public IActionResult OnGetEdit(int id)
        {
            var employer = _connection.GetEmployeeById(id);

            if (employer == null)
            {
                TempData["errorMessage"] = "Employer not found.";
                return RedirectToPage("/Mission/List");
            }

            return RedirectToPage();
        }
      /*  private void SendEmail(string emailAddress, string subject, string body)
        {

            var smtpClient = new SmtpClient
            {
 
            Host = "dridichady@gmail.com", 
            Port = 587, // Provide the SMTP port (usually 587 for TLS)
            UseDefaultCredentials = true,
            Credentials = new NetworkCredential("dridichady@gmail.com", "password"), // email to send
            EnableSsl = false 
        };
        

            var mailMessage = new MailMessage
            {
                From = new MailAddress("dridichady@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailAddress);

            smtpClient.Send(mailMessage);
        }



        */
    }
}
