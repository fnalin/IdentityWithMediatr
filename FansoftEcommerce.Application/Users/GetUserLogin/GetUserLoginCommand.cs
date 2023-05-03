using MediatR;

namespace FansoftEcommerce.Application.Users.GetUserLogin;

public record GetUserLoginCommand(string Email, string Password):IRequest<UserResponse>;