
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AST1.Models
{  //Classe des attributs et fonctions du mission avec l'employé et le hardware affecté. 
    public class Mission
    {
        [Key]
        public int IdMission { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
      //  public String? DateMission { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public String? DateReturnMission { get; set; }

        public string DescriptionMission { get; set; }

        public string EmplacementMission { get; set; }

        public string MvMission { get; set; }

        public string InsMission { get; set; }

        public int? IdEmployer { get; set; }
     
        public int? IdHardware { get; set; }

        public Mission()
        {

        }

       // public virtual Employer IdEmployerNavigation { get; set; }

    //    public virtual Hardware IdHardwareNavigation { get; set; }
    }
}
