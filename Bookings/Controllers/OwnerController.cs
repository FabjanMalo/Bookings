using Bookings.Application.Owners.Create;
using Bookings.Application.Owners.Update;
using Bookings.Domain.ApartmentOwners;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class OwnerController(ISender _sender) : ControllerBase
{
    [HttpPost]

    public async Task<IResult> CreateOwner([FromBody] CreateApartmentOwnerDto apartmentOwnerDto)
    {
        var command = new CreateOwnerCommand { CreateApartmentOwnerDto = apartmentOwnerDto };

        var result = await _sender.Send(command);

        return Results.Ok(result);
    }


    [HttpPut]

    public async Task<IResult> UpdateOwner([FromBody] UpdateOwnerDto ownerDto)
    {
        var command = new UpdateOwnerCommand { UpdateOwnerDto = ownerDto };

        var result = await _sender.Send(command);

        return Results.Ok(result);
    }
}
