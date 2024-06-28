using Bookings.Domain.Apartments;
using Bookings.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Bookings;
public class CreateBookingDto
{
    public Guid ApartmentId { get; init; }
    public Guid UserId { get; init; }
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
  
}
