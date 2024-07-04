using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Confirm;
public record ConfirmBookingCommand : IRequest
{
    public BookingDto BookingDto { get; set; }
}
