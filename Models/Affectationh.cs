using System;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{       // Classe Affectationh Admettant les attributs liée a chaque affectation (chaque affectation est une 
    //instance de ce classe 
    public class Affectationh
    {
        public int IdAffectation { get; set; }

        public string DesciptionAffectation { get; set; }

        public string MvAffectation { get; set; }

        public string InsAffectation { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateAffectation { get; set; }

        public string TypeAffectation { get; set; }

        public string IdHardware { get; set; }

        public string IdEmployer { get; set; }
    }
}
