using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Update;
public class UpdateApartmentCommandValidation : AbstractValidator<UpdateApartmentCommand>
{
    public UpdateApartmentCommandValidation()
    {
        RuleFor(x => x.ApartmentDetailDto.Id)
            .NotNull().WithMessage("{PropertyName} must be present");

        RuleFor(x => x.ApartmentDetailDto.Name).NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.ApartmentDetailDto.Address).NotEmpty();
    }
}
