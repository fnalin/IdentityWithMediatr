using Microsoft.IdentityModel.Tokens;

namespace FansoftEcommerce.Infra.Identity.Configuration;

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public SigningCredentials? SigningCredentials { get; set; } = null;
    public int Expiration { get; set; }
};
