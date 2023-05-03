using FansoftEcommerce.Application.Common;

namespace FansoftEcommerce.Application.Users;

public record UserResponse(string Id, string Email, string? Token = null) : IResponse;