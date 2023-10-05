
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{               // Classe ayant les informations de l'ordre demandé , avec la quantité et l'Id du fournisseur 
    public class Order
    {
       // public Order() => this.Hardwareh = (ICollection<Hardware>)new HashSet<Hardware>();
        [Key]
       public int IdOrder { get; set; }

        public string DesignationOrder { get; set; }

        public string ReferenceOrder { get; set; }

        public int QuantiteOrder { get; set; }

        public int QtsOrder { get; set; }

        public string SnOrder { get; set; }

        public string InsOrder { get; set; }

        public int? IdProvider { get; set; }

       // public virtual Provider IdProviderNavigation { get; set; }

       // public virtual ICollection<Hardware> Hardwareh { get; set; }
    }
}
