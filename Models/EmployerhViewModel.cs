using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AST1.Models
{
    public class EmployerhViewModel
    {
        [Key]
        public int IdEmployer { get; set; }

        public string NomEmployer { get; set; }

        public string PrenomEmployer { get; set; }

        public string EmailEmployer { get; set; }

        public string? PosteEmployer { get; set; }

        public string? TelephoneEmployer { get; set; }
        public string PasswordEmployer { get; set; }
        public string? Services { get; set; }
    }

}
