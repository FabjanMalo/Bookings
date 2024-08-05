using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Update;
public class UpdateOwnerCommandValidation : AbstractValidator<UpdateOwnerCommand>
{
    public UpdateOwnerCommandValidation()
    {
        RuleFor(x => x.UpdateOwnerDto.Id)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} must be present");

        RuleFor(c => c.UpdateOwnerDto.Email)
           .NotEmpty()
           .EmailAddress().WithMessage("Invalid email address format.");

        RuleFor(x => x.UpdateOwnerDto.Password)
           .MinimumLength(6)
           .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
           .Matches("[!@#$%^&*(),.?\":{}|<>]")
           .WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.UpdateOwnerDto.FirstName)
              .NotEmpty().WithMessage("First name is required.")
              .MaximumLength(30);

        RuleFor(x => x.UpdateOwnerDto.LastName)
              .NotEmpty().WithMessage("Last name is required.")
              .MaximumLength(30);

        RuleFor(c => c.UpdateOwnerDto.PhoneNumber)
           .NotEmpty().WithMessage("Phone number is required.");

        RuleFor(c => c.UpdateOwnerDto.IdentityCardNumber)
           .NotEmpty().WithMessage("Identity card number is required.")
           .Matches("[A-Z]");

        RuleFor(c => c.UpdateOwnerDto.ApartmentsId)
            .NotNull()
            .NotEmpty();
    }
}
