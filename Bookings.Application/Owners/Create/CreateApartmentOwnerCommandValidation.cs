using Bookings.Application.Owners.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Create;
public class CreateApartmentOwnerCommandValidation : AbstractValidator<CreateOwnerCommand>
{
    public CreateApartmentOwnerCommandValidation()
    {
        RuleFor(c => c.CreateApartmentOwnerDto.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.CreateApartmentOwnerDto.Password)
           .MinimumLength(6)
           .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
           .Matches("[!@#$%^&*(),.?\":{}|<>]")
           .WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.CreateApartmentOwnerDto.FirstName)
              .NotEmpty().WithMessage("First name is required.")
              .MaximumLength(30);

        RuleFor(x => x.CreateApartmentOwnerDto.LastName)
              .NotEmpty().WithMessage("Last name is required.")
              .MaximumLength(30);

        RuleFor(c => c.CreateApartmentOwnerDto.PhoneNumber)
           .NotEmpty().WithMessage("Phone number is required.");

        RuleFor(c => c.CreateApartmentOwnerDto.IdentityCardNumber)
           .NotEmpty().WithMessage("Identity card number is required.")
           .Matches("[A-Z]");

        RuleFor(c => c.CreateApartmentOwnerDto.ApartmentsId)
            .NotNull()
            .NotEmpty();
    }
}
