using Bookings.Application.Reviews.Create;
using Bookings.Domain.Reviews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ReviewController(ISender _sender) : ControllerBase
{
    [HttpPost("Create")]

    public async Task<IResult> Create([FromBody] CreateReviewDto reviewDto)
    {
        var review = new CreateReviewCommand { CreateReviewDto = reviewDto };

        var result = await _sender.Send(review);

        return Results.Ok(result);
    }
}
