using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.ChangePassword;
public class ChangePasswordUserValidation : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordUserValidation()
    {
        RuleFor(x => x.ChangePasswordDto.NewPassword)
           .MinimumLength(6)
           .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
           .Matches("[!@#$%^&*(),.?\":{}|<>]")
           .WithMessage("Password must contain at least one special character.");
    }
}
