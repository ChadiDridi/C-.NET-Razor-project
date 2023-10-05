namespace AST1.Models
{      
    public interface IAppUser
    {
        string Username { get; }

        string DisplayName { get; }

        string Email { get; }

        string[] Roles { get; }
    }
}
