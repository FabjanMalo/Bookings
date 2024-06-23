using Bookings.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.Register;
public class RegisterUserCommand : IRequest<Guid>
{
    public UserDto UserDto { get; set; }
}
