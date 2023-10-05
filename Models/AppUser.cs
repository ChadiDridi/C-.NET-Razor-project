namespace AST1.Models
{
    public class AppUser : IAppUser
    {
        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string[] Roles { get; set; }
    }
}