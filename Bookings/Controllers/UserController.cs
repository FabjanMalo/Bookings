using Bookings.Application;
using Bookings.Application.Users.Register;
using Bookings.Domain.Apartments;
using Bookings.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController(ISender _sender) : ControllerBase
{
    [HttpPost]

    public async Task<IResult> Register([FromBody] UserDto userDto)
    {

        var command = new RegisterUserCommand { UserDto = userDto };

        var result = await _sender.Send(command);

        return Results.Ok(result);
    }
}
