using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Apartments.Create;
public class CreateApartmentCommandValidation : AbstractValidator<CreateApartmentCommand>
{
    public CreateApartmentCommandValidation()
    {
        RuleFor(x=>x.CreateApartmentDto.Name).NotNull().NotEmpty();

        RuleFor(x=>x.CreateApartmentDto.Address).NotNull().NotEmpty();

        
    }
}
