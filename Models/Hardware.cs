using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AST1.Models
{

    /* Classe Hardware ayant les attributs de hardware et les implémentation de ces interfaces 
     * Pourquoi des interfaces ? c'est le principe du Design Patterns afin de faire des differents implémentations 
     * Donc l'interface reste en intermediaire entre les differents classes qu'ils l'utilisent afin de faciliter 
     * L'implementation et sa modification dans le projet futur sans devoir changer tous les classes qu'ils l'utilise. */



    public class Hardware
    {       
        public Hardware()
        {
          //  this.Affectations = (ICollection<Affectation>)new HashSet<Affectation>();
           // this.Missions = (ICollection<Mission>)new HashSet<Mission>();
        }

        //internal static IEnumerable<Hardware> SetViewTempSource() => throw new NotImplementedException();
        [Key]
        public int IdHardware { get; set; }

        public string SnHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string? DateHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DefaultValue("GetDate")]
        public string? DatecreateHardware { get; set; }

        public string DescriptionHardware { get; set; }

        [BindProperty]
        public string TypeHardware { get; set; }

        public string EtatHardware { get; set; }

        public string MarqueHardware { get; set; }

        public string ModelHardware { get; set; }

        public int? AvailableHardware { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string ? GrantieHardware { get; set; }

        public int? ConsommableHardware { get; set; }

        public string LoginHardware { get; set; }

        public int? IdOrder { get; set; }

       // public virtual Order IdOrderNavigation { get; set; }

      //  public virtual ICollection<Affectation> Affectations { get; set; }

       // public virtual ICollection<Mission> Missions { get; set; }
    }
}
