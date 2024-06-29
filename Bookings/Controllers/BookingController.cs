using Bookings.Application.Bookings.Complete;
using Bookings.Application.Bookings.Create;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class BookingController(ISender _sender) : ControllerBase
{
    [HttpPost]

    public async Task<IResult> Create([FromBody] CreateBookingDto createBookingDto)
    {
        var booking = new CreateBookingCommand { CreateBookingDto = createBookingDto };

        var result = await _sender.Send(booking);

        return Results.Ok(result);

    }

    [HttpPut]
    public async Task<IResult> CompletedOnUtc([FromBody] CompletedBookingDto bookingDto)
    {
        var booking = new CompletedBookingCommand { CompletedBookingDto = bookingDto };

        await _sender.Send(booking);

        return Results.NoContent();

    }

}
