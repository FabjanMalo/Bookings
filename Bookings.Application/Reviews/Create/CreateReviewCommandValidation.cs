using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Reviews.Create;
public class CreateReviewCommandValidation : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidation()
    {
        RuleFor(c => c.CreateReviewDto.BookingId).NotEmpty();

        RuleFor(c => c.CreateReviewDto.Rating)
            .GreaterThan(0)
            .LessThan(6)
            .NotEmpty().WithMessage("Rating is required");

        RuleFor(c => c.CreateReviewDto.Comment)
            .MaximumLength(100);
    }
}
