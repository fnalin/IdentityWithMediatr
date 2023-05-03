using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FansoftEcommerce.Application.Services;
using FansoftEcommerce.Domain.Users;
using FansoftEcommerce.Infra.Identity.Configuration;
using Microsoft.Extensions.Options;

namespace FansoftEcommerce.Infra.Identity.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    public TokenService(IOptions<JwtOptions> jwtOptions) => _jwtOptions = jwtOptions.Value;


    public string GetToken(User user)
    {
        var tokenClaims = GetClaims(user);
        var dataExpire = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: tokenClaims,
            notBefore: DateTime.Now,
            expires: dataExpire,
            signingCredentials: _jwtOptions.SigningCredentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }

    private  IList<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>();
        
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        user.Roles.ToList().ForEach(role=>claims.Add(new Claim("role", role.RoleId)));

        return claims;
    }
}