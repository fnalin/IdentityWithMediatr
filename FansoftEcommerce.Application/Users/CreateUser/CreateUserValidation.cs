using FluentValidation;

namespace FansoftEcommerce.Application.Users.CreateUser;

public class CreateUserValidation : AbstractValidator<CreateUserCommand>
{

    public CreateUserValidation()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(50);

        RuleFor(x => x.PasswordConfirmed)
            .Equal(x => x.Password);

    }
    
}