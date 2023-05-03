using FansoftEcommerce.Application.Data;
using FansoftEcommerce.Domain.Common;
using FansoftEcommerce.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace FansoftEcommerce.Infra.Identity.Repository;

public class UserRepository : IUserRepository
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    
    public UserRepository(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    public async Task AddAsync(User user)
    {
        var identityUser = new IdentityUser
        {
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(identityUser, user.Password);
        if (result.Succeeded)
        {
            await _userManager.SetLockoutEnabledAsync(identityUser, false);
        }
        user.SetUserId(identityUser.Id);
        
        if (!result.Succeeded && result.Errors.Any())
        {
            var errors = result.Errors.Select(x => x.Description);
            throw new DomainException(errors);
        }
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, true);
        IdentityUser? user;
        if (result.Succeeded)
        {
            user =  await _userManager.FindByEmailAsync(email);
        }
        else
        {
            var errors = new List<string>();
            
            if (result.IsLockedOut) errors.Add("account blocked");
            if (result.IsNotAllowed) errors.Add("this account not been permission to login");
            if (result.RequiresTwoFactor) errors.Add("this account require two factor");
            if (errors.Count == 0) errors.Add("user or password is invalid");

            throw new DomainException(errors);
        }


        var userLogin = User.Create(
            email, email, password);
        userLogin.SetUserId(user!.Id);

        var claimsUser = await _userManager.GetClaimsAsync(user);
        claimsUser?.ToList().ForEach(claim =>
        {
            var userClaim = UserClaim.Create(claim.Type, claim.Value);
            userLogin.AddClaim(userClaim);
        });

        var rolesUser = await _userManager.GetRolesAsync(user);
        rolesUser?.ToList().ForEach(role =>
        {
            var userRole = UserRole.Create(role);
            userLogin.AddRole(userRole);
        });

        return userLogin;
    }

    private void GeralToken(string email)
    {
        return;
    }
}