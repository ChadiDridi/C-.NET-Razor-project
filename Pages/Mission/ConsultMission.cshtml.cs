using AST1.SQLConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AST1.Pages.Mission
{
    public class ConsultMissionModel : PageModel
    {
        private  Connection _connection;

        public ConsultMissionModel(Connection connection)
        {
            _connection = connection;
        }

        [BindProperty]
        public Models.Mission NewMission { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnPost()
        {

            var mission = new Models.Mission
            {
                
                DateReturnMission = NewMission.DateReturnMission,
                IdEmployer = NewMission.IdEmployer,
                IdHardware = NewMission.IdHardware,
                InsMission = NewMission.InsMission,
                MvMission = NewMission.MvMission,
                DescriptionMission = NewMission.DescriptionMission,
                EmplacementMission = NewMission.EmplacementMission
            };
            _connection.Missions.Add(mission);
            _connection.SaveChanges();
            ViewData["Message"] = "Mission Added Successfully";
            return Redirect("/Mission/List");
        }
    }

}


