using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{
    /*Classe hardware ayant seulement les attribut d'un hardware */ 
    public class Hardwareh
    {           
        public int IdHardware { get; set; }

        public string SnHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DefaultValue("GetDate")]
        public DateTime? DatecreateHardware { get; set; }

        public string DescriptionHardware { get; set; }

        public string TypeHardware { get; set; }

        public string EtatHardware { get; set; }

        public string MarqueHardware { get; set; }

        public string ModelHardware { get; set; }

        public bool? AvailableHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? GrantieHardware { get; set; }

        public bool? ConsommableHardware { get; set; }

        public string LoginHardware { get; set; }

        public string IdOrder { get; set; }
    }
}
