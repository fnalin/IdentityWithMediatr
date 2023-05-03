using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Application.Services;
using MediatR;

namespace FansoftEcommerce.Application.Users.GetUserLogin;

public class GetUserLoginHandler : IRequestHandler<GetUserLoginCommand, UserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public GetUserLoginHandler(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    public async Task<UserResponse> Handle(GetUserLoginCommand request, CancellationToken cancellationToken)
    {
        var data = await _userRepository.LoginAsync(request.Email, request.Password);
        var token = _tokenService.GetToken(data);
        var response = new UserResponse(data.Id.Value, data.Email, token);
        return response;
    }
}