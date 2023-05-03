namespace FansoftEcommerce.Domain.Users;

public class User
{


    private readonly List<UserClaim> _claims = new();
    private readonly List<UserRole> _roles = new();

    public UserId Id { get; private set; } = null!;
    public string Email { get; private set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public IReadOnlyList<UserClaim> Claims => _claims.ToList();
    public IReadOnlyList<UserRole> Roles => _roles.ToList();

    public void AddClaim(UserClaim claim) => _claims.Add(claim);
    public void AddRole(UserRole role) => _roles.Add(role);
    

    public static User Create(string email, string userName, string password)
    {
        return new User()
        {
            Email = email, 
            UserName = userName,
            Password = password
        };
    }

    public void SetUserId(string id) => Id = new UserId(id);
}