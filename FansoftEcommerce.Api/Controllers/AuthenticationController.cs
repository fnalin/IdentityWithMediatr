using FansoftEcommerce.Application.Users.GetUserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FansoftEcommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;
    public AuthenticationController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Add(GetUserLoginCommand command)
    {
        var data = await _sender.Send(command);
        return Ok(data);
    }
    
}