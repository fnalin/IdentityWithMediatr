using FluentValidation;

namespace FansoftEcommerce.Application.Users.GetUserLogin;

public class GetUserLoginValidation : AbstractValidator<GetUserLoginCommand>
{
    public GetUserLoginValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}