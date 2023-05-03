namespace FansoftEcommerce.Domain.Users;

public class UserClaim
{
    public string ClaimType { get; private set; } = null!;
    public string ClaimValue { get; private set; } = null!;

    public static UserClaim Create(string claimType, string claimValue) =>
        new UserClaim { ClaimType = claimType, ClaimValue = claimValue};
}