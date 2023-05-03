using FansoftEcommerce.Domain.Users;

namespace FansoftEcommerce.Application.Services;

public interface ITokenService : IService
{
    string GetToken(User user);
}