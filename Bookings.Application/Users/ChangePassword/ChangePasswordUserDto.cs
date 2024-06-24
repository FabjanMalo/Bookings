using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.ChangePassword;
public class ChangePasswordUserDto
{
    public string Email { get; init; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
}
