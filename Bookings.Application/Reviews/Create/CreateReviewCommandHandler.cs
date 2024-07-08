using Bookings.Application.Abstractions.Database;
using Bookings.Application.Users.Register;
using Bookings.Application.Users;
using Bookings.Domain.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookings.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Application.Reviews.Create;
public class CreateReviewCommandHandler(
    IApplicationContext _applicationContext,
    IReviewRepository _reviewRepository)
    : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly CreateReviewCommandValidation _validation = new();

    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var booking = await _applicationContext
            .Bookings
            .FirstOrDefaultAsync(c => c.Id == request.CreateReviewDto.BookingId, cancellationToken);

        if (booking is null)
        {
            throw new NotFoundException(nameof(booking), request.CreateReviewDto.BookingId);
        }

        var review = Review.CreateReview(request.CreateReviewDto);

        await _reviewRepository.Add(review);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return review.Id;
    }
}
