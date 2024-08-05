using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Owners.Update;
public class UpdateOwnerDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string PhoneNumber { get; init; }
    public string IdentityCardNumber { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }

    public List<Guid> ApartmentsId { get; init; }
}
