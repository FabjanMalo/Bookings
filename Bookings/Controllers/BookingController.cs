using Bookings.Application.Bookings;
using Bookings.Application.Bookings.Cancel;
using Bookings.Application.Bookings.Complete;
using Bookings.Application.Bookings.Confirm;
using Bookings.Application.Bookings.Create;
using Bookings.Application.Bookings.Reject;
using Bookings.Domain.Bookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class BookingController(ISender _sender) : ControllerBase
{
    [HttpPost("Reserve")]

    public async Task<IResult> Create([FromBody] CreateBookingDto createBookingDto)
    {
        var booking = new CreateBookingCommand { CreateBookingDto = createBookingDto };

        var result = await _sender.Send(booking);

        return Results.Ok(result);

    }

    [HttpPut("CompletedOnUtc")]
    public async Task<IResult> CompletedOnUtc([FromBody] BookingDto bookingDto)
    {
        var booking = new CompletedBookingCommand { BookingDto = bookingDto };

        await _sender.Send(booking);

        return Results.NoContent();

    }

    [HttpPut("RejectedOnUtc")]
    public async Task<IResult> RejectedOnUtc([FromBody] BookingDto bookingDto)
    {
        var booking = new RejectBookingCommand { BookingDto = bookingDto };

        await _sender.Send(booking);

        return Results.NoContent();

    }

    [HttpPut("CanelledOnUtc")]
    public async Task<IResult> CanelledOnUtc([FromBody] BookingDto bookingDto)
    {
        var booking = new CancelBookingCommand { BookingDto = bookingDto };

        await _sender.Send(booking);

        return Results.NoContent();

    }

    [HttpPut("ConfirmedOnUtc")]
    public async Task<IResult> ConfirmedOnUtc([FromBody] BookingDto bookingDto)
    {
        var booking = new ConfirmBookingCommand { BookingDto = bookingDto };

        await _sender.Send(booking);

        return Results.NoContent();

    }

}
