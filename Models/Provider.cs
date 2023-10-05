



























using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AST1.Models
{    /*Classe des providers de materiel*/ 
    public class Provider
    {
       // public Provider() => this.Orders = (ICollection<Order>)new HashSet<Order>();
        [Key]
        public int IdProvider { get; set; }

        public string RaisonSocialProvider { get; set; }

        public string NameProvider { get; set; }

        public string AdresseProvider { get; set; }

        public string PaysProvider { get; set; }

        public string MailProvider { get; set; }

        public string? PrincipalProvider { get; set; }

        public string? ActifProvider { get; set; }

        public string PhoneProvider { get; set; }

        public string? Phone2Provider { get; set; }

      //  public virtual ICollection<Order> Orders { get; set; }  /*Fonction virtuelle (sera développé pour les classes d'héritage , c'est une interface de collection des differents ordres */ 
    }
}
