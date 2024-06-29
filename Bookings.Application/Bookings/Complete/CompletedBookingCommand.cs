using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Bookings.Complete;
public record CompletedBookingCommand : IRequest
{
    public CompletedBookingDto CompletedBookingDto { get; set; }
}
