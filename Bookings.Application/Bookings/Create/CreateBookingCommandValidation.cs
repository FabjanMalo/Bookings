using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Create;
public class CreateBookingCommandValidation : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidation()
    {
        RuleFor(x => x.CreateBookingDto.Start.Day)
            .GreaterThan(0)
            .LessThanOrEqualTo(31);

        RuleFor(x => x.CreateBookingDto.End.Day)
        .GreaterThan(0)
        .LessThanOrEqualTo(31);
    }
}
