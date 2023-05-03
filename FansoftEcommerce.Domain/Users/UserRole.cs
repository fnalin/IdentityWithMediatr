namespace FansoftEcommerce.Domain.Users;

public class UserRole
{
    public string RoleId { get; private set; } = null!;

    public static UserRole Create(string roleId) =>
        new UserRole { RoleId = roleId};
}