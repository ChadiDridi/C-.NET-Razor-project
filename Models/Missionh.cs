using System;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{
    public class Missionh
    {
        public int IdMission { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateMission { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateReturnMission { get; set; }

        public string DescriptionMission { get; set; }

        public string EmplacementMission { get; set; }

        public string MvMission { get; set; }

        public string InsMission { get; set; }

        public string IdEmployer { get; set; }

        public string IdHardware { get; set; }
    }
}
