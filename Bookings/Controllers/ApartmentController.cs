using Bookings.Application.Apartments.Create;
using Bookings.Application.Apartments.Delete;
using Bookings.Application.Apartments.Get;
using Bookings.Application.Apartments.GetAll;
using Bookings.Application.Apartments.Update;
using Bookings.Domain.Apartments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ApartmentController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAll()
    {
        var query = new GetAllApartmentsQuery();

        var result = await _sender.Send(query);

        return Results.Ok(result);
    }

    [HttpGet("{id}")]
public async Task<IResult> Get(Guid id)
    {
        var query = new GetApartmentQuery();

        var result = await _sender.Send(query);

        return Results.Ok(result);
    }

    [HttpPost] 
    public async Task<IResult> Create([FromBody] CreateApartmentDto createApartmentDto)
    {
        var command = new CreateApartmentCommand{ CreateApartmentDto = createApartmentDto};

        var result = await _sender.Send(command);

        return Results.Ok(result);
    }

    [HttpPut]

    public async Task<IResult> Update([FromBody] ApartmentDetailDto apartmentDetailDto)
    {
        var command = new UpdateApartmentCommand { ApartmentDetailDto = apartmentDetailDto };

         await _sender.Send(command);

        return Results.NoContent();
    }

    [HttpDelete]
    public async Task<IResult> Delete(Guid id)
    {
        var command = new DeleteApartmentCommand { Id = id };

        await _sender.Send(command);

        return Results.NoContent();
    }

}
