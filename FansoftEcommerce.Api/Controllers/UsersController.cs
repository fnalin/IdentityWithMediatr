using FansoftEcommerce.Application.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FansoftEcommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender) => _sender = sender;
    
    [HttpPost]
    public async Task<IActionResult> Add(CreateUserCommand command)
    {
        var data = await _sender.Send(command);
        return Ok(data);
    }
    
}