namespace AST1.Models
{

    /*Classe de Ldap pour realiser la connection*/ 
    public class LdapConfig
    {
        public string Url { get; set; }

        public string BindDn { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string SearchBase { get; set; }

        public string SearchFilter { get; set; }
    }
}
