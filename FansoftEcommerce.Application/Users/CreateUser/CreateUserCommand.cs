using MediatR;

namespace FansoftEcommerce.Application.Users.CreateUser;

public record CreateUserCommand(string Email, string Password, string PasswordConfirmed) : IRequest<UserResponse>;