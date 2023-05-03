using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Domain.Users;
using MediatR;

namespace FansoftEcommerce.Application.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = User.Create(
            request.Email, 
            request.Email, 
            request.Password);
        await _userRepository.AddAsync(newUser);

        return new UserResponse(newUser.Id.Value, newUser.Email);
    }
}