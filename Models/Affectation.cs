using System;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{
    public class Affectation
    {       // ce classe d'affectation admet les attributs d'une affectation du hardware pris par un employé 
        //avec une date et description 
        [Key]
        public int IdAffectation { get; set; }

        public string DesciptionAffectation { get; set; }

        public string InsAffectation { get; set; }

        public string MvAffectation { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateAffectation { get; set; }

        public string TypeAffectation { get; set; }

        public int? IdHardware { get; set; }

        public int? IdEmployer { get; set; }

       // public virtual Employer IdEmployerNavigation { get; set; }

    //    public virtual Hardware IdHardwareNavigation { get; set; }
    }
}
