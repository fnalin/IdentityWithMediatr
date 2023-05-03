using FansoftEcommerce.Domain.Users;

namespace FansoftEcommerce.Application.Data;

public interface IUserRepository : IRepository
{
    Task AddAsync(User user);
    Task<User> LoginAsync(string email, string password);
}