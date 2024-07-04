using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Cancel;
public record CancelBookingCommand : IRequest
{
    public BookingDto BookingDto { get; set; }
}
