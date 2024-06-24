using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.ChangePassword;
public class ChangePasswordCommand : IRequest<Unit>
{
    public ChangePasswordUserDto ChangePasswordDto { get; set; }
}
